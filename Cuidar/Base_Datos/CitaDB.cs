using System;
using System.Collections.Generic;
using System.Linq;
using Cuidar.Models;
using System.Data.SqlClient;
using System.Data;

namespace Cuidar.Base_Datos
{
    public class CitaDB
    {
        ContextDB contextDB = new ContextDB();
        PersonaDB personaDB = new PersonaDB();
        EstadoCitaDB estadoCitaDB = new EstadoCitaDB();
        IncidenciaCitaDB incidenciaCitaDB = new IncidenciaCitaDB();

        public void AgregarCita(Cita cita)
        {
            using (SqlConnection con = contextDB.DbConnection())
            {
                SqlCommand cmd = new SqlCommand("agregarCita", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@paciente_id", cita.pacienteID);
                cmd.Parameters.AddWithValue("@especialista_id", cita.especialistaID);
                cmd.Parameters.AddWithValue("@cita_id", cita.citaID = getIDCita());
                cmd.Parameters.AddWithValue("@cita_fecha", cita.citaFecha);
                cmd.Parameters.AddWithValue("@cita_hora", cita.citaHora);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            incidenciaCitaDB.crearIncidenciaCita(cita.citaID, 1, "Cita creada el dia " + DateTime.Now.ToShortDateString().ToString());
        }
        public int getIDCita()
        {
            if (getCitas().Any())
            {
                var idCita = (getCitas().Max(x => x.citaID) + 1);
                return idCita;
            }
            else
            {
                return 1;
            }
        }        
        private IEnumerable<Cita> getCitas()
        {
            List<Cita> listaCitas = new List<Cita>();
            using (SqlConnection con = contextDB.DbConnection())
            {
                SqlCommand cmd = new SqlCommand("getCitas", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Cita cita = new Cita();
                    cita.pacienteID = Convert.ToInt16(rdr["paciente_id"]);
                    cita.citaID = Convert.ToInt16(rdr["cita_id"]);
                    cita.especialistaID = Convert.ToInt16(rdr["especialista_id"]);
                    cita.citaFecha = Convert.ToDateTime(rdr["cita_fecha"].ToString());
                    cita.citaHora = rdr.GetTimeSpan(rdr.GetOrdinal("cita_hora"));
                    cita.estadoCitaID = Convert.ToInt16(rdr["estadocita_id"]);
                    listaCitas.Add(cita);
                }
                con.Close();
            }
            return listaCitas;
        }
        public IEnumerable<object> getCitasPorPersona(int ID)
        {
            IEnumerable<Cita> getCitaResultado = getCitas();
            if (getCitaResultado.Any(c => c.pacienteID == ID))
            {
                IEnumerable<Persona> getEspecialistaCita = personaDB.getPersonas();
                IEnumerable<EstadoCita> getEstadoCita = estadoCitaDB.getEstadoCita();
                var getCita = getCitas().Join(getEspecialistaCita, x => x.especialistaID, y => y.personaID, (x, y) =>
                new { x.citaID, y.personaNombre, y.personaApellido1, y.personaApellido2, x.citaFecha, x.citaHora, x.estadoCitaID }).OrderBy(x => x.citaHora)
                .Join(getEstadoCita, x => x.estadoCitaID, y => y.EstadoCitaID, (x, y) => new
                { x.citaID, x.personaNombre, x.personaApellido1, x.personaApellido2, x.citaFecha, x.citaHora, x.estadoCitaID, y.EstadoCitaNombre }).OrderBy(x => x.citaFecha);
                return getCita;
            }
            else
            {
                return getCitaResultado = Enumerable.Empty<Cita>();
            }
        }
        public IEnumerable<Cita> getCitaPorId(int idCita)
        {
            IEnumerable<Cita> getCitaResultado = getCitas().Where(c => c.citaID == idCita);
            return getCitaResultado;
        }
        public IEnumerable<Cita> getCitasPorEspecialista(int idEspecialista)
        {
            IEnumerable<Cita> getCitaEspecialista = getCitas().Where(x => x.especialistaID == idEspecialista);
            return getCitaEspecialista;
        }

        public void cancelarCita(int idCita, string incidenciaDetalle)
        {
            using (SqlConnection con = contextDB.DbConnection())
            {
                SqlCommand cmd = new SqlCommand("cancelarCitaUsuario", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cita_id", idCita);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            incidenciaCitaDB.crearIncidenciaCita(idCita, 2, incidenciaDetalle);
        }
        public Boolean RevisionHorarioCita(int idCita)
        {
            Boolean validarHorarioCita = false;
            IEnumerable<Cita> listaCitaPorID = getCitaPorId(idCita);
            foreach (Cita cita in listaCitaPorID)
            {
                DateTime diaCita = cita.citaFecha;
                DateTime diaActual = DateTime.Now.Date;
                if (diaActual == diaCita)
                {
                    TimeSpan horaActual = DateTime.Now.TimeOfDay;
                    TimeSpan horaCita = cita.citaHora;
                    if (horaCita.TotalMinutes - horaActual.TotalMinutes < 120)
                    {
                        validarHorarioCita = true;
                    }
                }
            }    
            return validarHorarioCita;
        }
    }
}
            