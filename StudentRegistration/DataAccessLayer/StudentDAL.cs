using StudentRegistration.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Asn1.IsisMtt.X509;

namespace StudentRegistration.DataAccessLayer
{
    public class StudentDAL
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        // Method to get all students
        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("GetAllStudents", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Student student = new Student
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        FirstName = reader["FirstName"].ToString(),
                        MiddleName = reader["MiddleName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        MotherName = reader["MotherName"].ToString(),
                        Gender = reader["Gender"].ToString(),
                        MobileNumber = reader["MobileNumber"].ToString(),
                        Email = reader["Email"].ToString(),
                        DateOfBirth = reader.IsDBNull(reader.GetOrdinal("DateOfBirth"))
                                ? (DateTime?)null
                                : Convert.ToDateTime(reader["DateOfBirth"]),
                        Address = reader["Address"].ToString(),  // New field
                        Admission_Type = reader["Admission_Type"].ToString(),
                        Registration_Number = reader["Registration_Number"].ToString(),
                        Ranking = reader["Ranking"].ToString(),
                        Category = reader["Category"].ToString(),
                        Branch = reader["Branch"].ToString(),
                        Admission_Year = reader["Admission_Year"].ToString()

                    };

                    students.Add(student);
                }
                reader.Close();
            }
            return students;
        }

        // Method to get student by ID
        public Student GetStudentById(int id)
        {
            Student student = null;

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("GetStudentById", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@p_Id", id);

                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    student = new Student
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        FirstName = reader["FirstName"].ToString(),
                        MiddleName = reader["MiddleName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        MotherName = reader["MotherName"].ToString(),
                        Gender = reader["Gender"].ToString(),
                        MobileNumber = reader["MobileNumber"].ToString(),
                        Email = reader["Email"].ToString(),
                        DateOfBirth = reader.IsDBNull(reader.GetOrdinal("DateOfBirth"))
                                ? (DateTime?)null  // Handle null values
                                : Convert.ToDateTime(reader["DateOfBirth"]),
                        Address = reader["Address"].ToString(), // New field
                        Admission_Type = reader["Admission_Type"].ToString(),
                        Registration_Number = reader["Registration_Number"].ToString(),
                        Ranking = reader["Ranking"].ToString(),
                        Category = reader["Category"].ToString(),
                        Branch = reader["Branch"].ToString(),
                        Admission_Year = reader["Admission_Year"].ToString()
                    };
                }
                reader.Close();
            }
            return student;
        }

        // Method to add a  students
        public void AddStudent(Student student)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("AddStudent", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@p_FirstName", student.FirstName);
                cmd.Parameters.AddWithValue("@p_MiddleName", student.MiddleName);
                cmd.Parameters.AddWithValue("@p_LastName", student.LastName);
                cmd.Parameters.AddWithValue("@p_MotherName", student.MotherName);
                cmd.Parameters.AddWithValue("@p_Gender", student.Gender);
                cmd.Parameters.AddWithValue("@p_MobileNumber", student.MobileNumber);
                cmd.Parameters.AddWithValue("@p_Email", student.Email);
                cmd.Parameters.AddWithValue("@p_DateOfBirth", student.DateOfBirth);  
                cmd.Parameters.AddWithValue("@p_Address", student.Address); 
                cmd.Parameters.AddWithValue("@p_Admission_Type", student.Admission_Type);
                cmd.Parameters.AddWithValue("@p_Registration_Number", student.Registration_Number);
                cmd.Parameters.AddWithValue("@p_Ranking", student.Ranking);
                cmd.Parameters.AddWithValue("@p_Category", student.Category);
                cmd.Parameters.AddWithValue("@p_Branch", student.Branch);
                cmd.Parameters.AddWithValue("@p_Admission_Year", student.Admission_Year);


                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Method to update a student
        public void UpdateStudent(Student student)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("UpdateStudent", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@p_Id", student.Id);
                cmd.Parameters.AddWithValue("@p_FirstName", student.FirstName);
                cmd.Parameters.AddWithValue("@p_MiddleName", student.MiddleName);
                cmd.Parameters.AddWithValue("@p_LastName", student.LastName);
                cmd.Parameters.AddWithValue("@p_MotherName", student.MotherName);
                cmd.Parameters.AddWithValue("@p_Gender", student.Gender);
                cmd.Parameters.AddWithValue("@p_MobileNumber", student.MobileNumber);
                cmd.Parameters.AddWithValue("@p_Email", student.Email);
                cmd.Parameters.AddWithValue("@p_DateOfBirth", student.DateOfBirth);  // New field
                cmd.Parameters.AddWithValue("@p_Address", student.Address);  // New field
                cmd.Parameters.AddWithValue("@p_Admission_Type", student.Admission_Type);
                cmd.Parameters.AddWithValue("@p_Registration_Number", student.Registration_Number);
                cmd.Parameters.AddWithValue("@p_Ranking", student.Ranking);
                cmd.Parameters.AddWithValue("@p_Category", student.Category);
                cmd.Parameters.AddWithValue("@p_Branch", student.Branch);
                cmd.Parameters.AddWithValue("@p_Admission_Year", student.Admission_Year);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Method to delete a student
        public void DeleteStudent(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("DeleteStudent", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@p_Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}