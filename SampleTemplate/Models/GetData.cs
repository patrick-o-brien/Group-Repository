﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using StudioBookingApp.Models;
using System.Web.Helpers;
using System.Xml;
using System.IO;
using System.Data;
using System.Web.Configuration;

namespace SampleTemplate.Models
{
    public class GetData:DAO
    {
        string message;
        
        public List<Studio> ShowAllStudios()
        {
            List<Studio> list = new List<Studio>();
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand("uspGetAllStudios", openConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Studio studio = new Studio();

                    studio.StudioID = reader[0].ToString();
                    studio.Name = reader[1].ToString();
                    studio.Image = reader[2].ToString();
                    studio.Type = reader[3].ToString();
                    studio.Description = reader[4].ToString();
                    studio.HourlyRate = decimal.Parse(reader[5].ToString());
                    list.Add(studio);
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            finally
            {
                closeConnnection();
            }
            return list;
        }

        public Reservation GetReservation(string reservationID)
        {
            Reservation reservation = new Reservation();
            SqlDataReader reader;

            SqlCommand cmd = new SqlCommand("uspGetReservation", openConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("ReservationID", reservationID);

            try
            {
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    reservation.ReservationID = reader[0].ToString();
                    reservation.StudioID = reader[1].ToString();
                    reservation.UserName = reader[2].ToString();
                    reservation.StartTime = DateTime.Parse(reader[3].ToString());
                    reservation.EndTime = DateTime.Parse(reader[4].ToString());
                    reservation.Cost = Decimal.Parse(reader[5].ToString());
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            finally
            {
                closeConnnection();
            }

            return reservation;
        }
        

    }
}