using Microsoft.Data.SqlClient;
using Models;
using System.Data.SqlTypes;
using System.Text;

namespace Repositories
{
    public class CarRepository
    {
        string srConn = @"Data Source=127.0.0.1;Initial Catalog=Aula2_Prof_Andre;User Id=SA;Password=SqlServer2019!;TrustServerCertificate=True"; //Funcionou ^^
        SqlConnection conn;

        public CarRepository()
        {
            conn = new SqlConnection(srConn);
            conn.Open();
        }
        public bool Insert(Car car)
        {
            bool result = false;

            try
            {
               
                SqlCommand cmd = new(Car.INSERT, conn);
                cmd.Parameters.Add(new SqlParameter("@Name", car.Name));
                cmd.Parameters.Add(new SqlParameter("@Color", car.Color));
                cmd.Parameters.Add(new SqlParameter("@Year", car.Year));
                cmd.ExecuteNonQuery();
                result = true;
            }
            catch (Exception)
            {
                return result;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public bool Update(Car car)
        {
            bool result = false;
            try
            {
                SqlCommand cmd = new(Car.UPDATE, conn);
                cmd.Parameters.Add(new SqlParameter("@Id", car.Id));
                cmd.Parameters.Add(new SqlParameter("@Name", car.Name));
                cmd.Parameters.Add(new SqlParameter("@Color", car.Color));
                cmd.Parameters.Add(new SqlParameter("@Year", car.Year));
                cmd.ExecuteNonQuery();
                result = true;
            }
            catch (Exception)
            {
                return result;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public bool Delete(int id) 
        {
            bool result = false;

            try
            {
                SqlCommand cmd = new(Car.DELETE, conn);
                cmd.Parameters.Add(new SqlParameter("@Id", id));
                cmd.ExecuteNonQuery();
                result = true;
            }
            catch (Exception)
            {
                return result;
            }
            finally
            {
                conn.Close();
            }
                return true ;
        }

        public List<Car> GetAll()
        {
            List<Car> listCars = new List<Car>();

            //StringBuilder sb = new StringBuilder(); //Serve para fazer a concatenação de strings
            //sb.Append("SELECT Id, Name, Color, Year FROM TB_CAR"); //É uma boa prática não colocar o * no SELECT, porque a aplicação pode não aguentar puxar tantos dados no momento

            /*
            sb.Append("SELECT Id, ");
            sb.Append("     Name, ");
            sb.Append("     Color, ");
            sb.Append("     Year, ");
            sb.Append(" FROM TB_CAR ");
            */

            try
            {
                SqlCommand cmd = new SqlCommand(Car.GET_ALL, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Car car = new Car();

                    car.Id = reader.GetInt32(0);
                    car.Name = reader.GetString(1);
                    car.Color = reader.GetString(2);
                    car.Year = reader.GetInt32(3);
                    listCars.Add(car);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return listCars;
        }

        public Car Get(int id)
        {
            //StringBuilder sb = new StringBuilder(); //Serve para fazer a concatenação de strings
            //sb.Append("SELECT Id, Name, Color, Year FROM TB_CAR WHERE Id = @Id"); //É uma boa prática não colocar o * no SELECT, porque a aplicação pode não aguentar puxar tantos dados no momento

            Car car = new();

            try
            {
                SqlCommand cmd = new SqlCommand(Car.GET, conn);
                cmd.Parameters.Add(new SqlParameter("@Id", id));

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    car = new Car();
                    car.Id = reader.GetInt32(0);
                    car.Name = reader.GetString(1);
                    car.Color = reader.GetString(2);
                    car.Year = reader.GetInt32(3);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return car;
        }
    }
}
