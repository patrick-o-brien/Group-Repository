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
    public class AddData : DAO
    {
        string message; 

        public int InsertUser(User user)
        {
            int count = 0;
            string password;

            SqlCommand cmd = new SqlCommand("uspInsertUser", openConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@first", user.FirstName);
            cmd.Parameters.AddWithValue("@last", user.LastName);
            cmd.Parameters.AddWithValue("@email", user.Email);
            password = Crypto.HashPassword(user.Password);
            cmd.Parameters.AddWithValue("@pass", password);

            try
            {
                count = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            finally
            {
                closeConnnection();
            }
            return count;
        }

        public int InsertStudio(Studio studio)
        {
            int count = 0;

            SqlCommand cmd = new SqlCommand("uspInsertStudio", openConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", studio.StudioID);
            cmd.Parameters.AddWithValue("@Name", studio.Name);
            cmd.Parameters.AddWithValue("@Image", studio.Image);
            cmd.Parameters.AddWithValue("@Type", studio.Type);
            cmd.Parameters.AddWithValue("@Description", studio.Description);
            cmd.Parameters.AddWithValue("@HourlyRate", studio.HourlyRate);

            try
            {
                count = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            finally
            {
                closeConnnection();
            }
            return count;
        }

        public int InsertReservation(Reservation reservation)
        {
            int count = 0;

            SqlCommand cmd = new SqlCommand("uspInsertStudio", openConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ReservationID", reservation.ReservationID);
            cmd.Parameters.AddWithValue("@UserName", reservation.UserName);
            cmd.Parameters.AddWithValue("@StudioID", reservation.StudioID);
            cmd.Parameters.AddWithValue("@StartTime", reservation.StartTime);
            cmd.Parameters.AddWithValue("@EndTime", reservation.EndTime);
            cmd.Parameters.AddWithValue("@Cost", reservation.Cost);

            try
            {
                count = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            finally
            {
                closeConnnection();
            }
            return count;
        }
    }
}