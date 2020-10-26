using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DAL
{
    public class DAL_Vorlage
    {
        //        public static ObservableCollection<Artikel> Select(bool withDummi = false)
        //        {
        //            ObservableCollection<Artikel> result = new ObservableCollection<Artikel>();
        //            SqlDataAdapter da = new SqlDataAdapter();
        //            DataSet ds = new DataSet();
        //            SqlConnection sqlCon = Definitions.DBVerbindung.GetDBVerbindungBfDb();

        //            try
        //            {

        //                if (sqlCon.State != ConnectionState.Open) sqlCon.Open();

        //                String strSelectCommand = @"SELECT tbl_Brotzeitliste_Artikelliste.Id
        //      ,tbl_Brotzeitliste_Artikelliste.Bezeichnung
        //      ,[Preis]
        //      ,[Veraltet]
        //      ,[Zuordnung]
        //      ,ArtZuordnung.Bezeichnung as ZuordnungAsString
        //      ,[CreateDate]
        //      ,[CreateUser]
        //      ,[ChangeDate]
        //      ,[ChangeUser]
        //  FROM [dbo].[tbl_Brotzeitliste_Artikelliste]
        //INNER JOIN tbl_Brotzeitliste_Artikelzuordnung as ArtZuordnung ON tbl_Brotzeitliste_Artikelliste.Zuordnung = ArtZuordnung.Id";

        //                da.SelectCommand = new SqlCommand(strSelectCommand, sqlCon);

        //                da.Fill(ds);
        //                if (withDummi)
        //                {
        //                    result.Add(new Artikel { Id = Guid.Empty, Bezeichnung = "--- bitte wählen ---" });
        //                }

        //                if (ds.Tables != null && ds.Tables.Count > 0)
        //                {
        //                    foreach (DataRow dr in ds.Tables[0].Rows)
        //                    {
        //                        result.Add(new Artikel(dr));
        //                    }
        //                    //result = new Artikel(ds.Tables[0].Rows[0]);
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                result = null;
        //            }
        //            finally
        //            {
        //                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
        //            }
        //            return result;
        //        }

        //        public static void Insert(Artikel obj)
        //        {

        //            SqlConnection sqlCon = Definitions.DBVerbindung.GetDBVerbindungBfDb();

        //            try
        //            {
        //                if (sqlCon.State != ConnectionState.Open)
        //                {
        //                    sqlCon.Open();
        //                }

        //                String strInsertCommand = @"INSERT INTO [dbo].[tbl_Brotzeitliste_Artikelliste]
        //           ([Id]
        //           ,[Bezeichnung]
        //           ,[Preis]
        //           ,[Veraltet]
        //           ,[Zuordnung]
        //           ,[CreateDate]
        //           ,[CreateUser]
        //           ,[ChangeDate]
        //           ,[ChangeUser])
        //     VALUES
        //           (@Id
        //           ,@Bezeichnung
        //           ,@Preis
        //           ,@Veraltet
        //           ,@Zuordnung
        //           ,@CreateDate
        //           ,@CreateUser
        //           ,@ChangeDate
        //           ,@ChangeUser)";
        //                SqlCommand sqlCommand = new SqlCommand(strInsertCommand, sqlCon);
        //                sqlCommand = SetParameter(sqlCommand, obj);
        //                sqlCommand.ExecuteNonQuery();
        //            }
        //            catch (Exception ex)
        //            {

        //            }
        //            finally
        //            {
        //                if (sqlCon.State == ConnectionState.Open)
        //                {
        //                    sqlCon.Close();
        //                }
        //            }
        //        }

        //        public static void Update(Artikel obj)
        //        {
        //            SqlConnection sqlCon = Definitions.DBVerbindung.GetDBVerbindungBfDb();

        //            try
        //            {
        //                if (sqlCon.State != ConnectionState.Open)
        //                {
        //                    sqlCon.Open();
        //                }

        //                String strUpdateCommand = @"UPDATE [dbo].[tbl_Brotzeitliste_Artikelliste]
        //   SET [Id] = @Id
        //      ,[Bezeichnung] = @Bezeichnung
        //      ,[Preis] = @Preis
        //      ,[Veraltet] = @Veraltet
        //      ,[Zuordnung] = @Zuordnung
        //      ,[CreateDate] = @CreateDate
        //      ,[CreateUser] = @CreateUser
        //      ,[ChangeDate] = @ChangeDate
        //      ,[ChangeUser] = @ChangeUser
        // WHERE id = @Id";
        //                SqlCommand sqlCommand = new SqlCommand(strUpdateCommand, sqlCon);
        //                sqlCommand = SetParameter(sqlCommand, obj);
        //                sqlCommand.ExecuteNonQuery();
        //            }
        //            catch (Exception ex)
        //            {

        //            }
        //            finally
        //            {
        //                if (sqlCon.State == ConnectionState.Open)
        //                {
        //                    sqlCon.Close();
        //                }
        //            }
        //        }

        //        private static SqlCommand SetParameter(SqlCommand sqlCom, Artikel obj)
        //        {
        //            sqlCom.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier));
        //            sqlCom.Parameters.Add(new SqlParameter("@Bezeichnung", SqlDbType.NVarChar, 250));
        //            sqlCom.Parameters.Add(new SqlParameter("@Preis", SqlDbType.Float));
        //            sqlCom.Parameters.Add(new SqlParameter("@Veraltet", SqlDbType.Bit));
        //            sqlCom.Parameters.Add(new SqlParameter("@Zuordnung", SqlDbType.UniqueIdentifier));
        //            sqlCom.Parameters.Add(new SqlParameter("@CreateDate", SqlDbType.DateTime));
        //            sqlCom.Parameters.Add(new SqlParameter("@CreateUser", SqlDbType.NVarChar, 250));
        //            sqlCom.Parameters.Add(new SqlParameter("@ChangeDate", SqlDbType.DateTime));
        //            sqlCom.Parameters.Add(new SqlParameter("@ChangeUser", SqlDbType.NVarChar, 250));

        //            sqlCom.Parameters["@Id"].Value = obj.Id;
        //            sqlCom.Parameters["@Bezeichnung"].Value = !String.IsNullOrEmpty(obj.Bezeichnung) ? obj.Bezeichnung : String.Empty;
        //            sqlCom.Parameters["@Preis"].Value = obj.Preis;
        //            sqlCom.Parameters["@Veraltet"].Value = obj.Veraltet;
        //            sqlCom.Parameters["@Zuordnung"].Value = obj.Zuordnung;
        //            sqlCom.Parameters["@CreateDate"].Value = obj.CreateDate;
        //            sqlCom.Parameters["@CreateUser"].Value = obj.CreateUser;
        //            sqlCom.Parameters["@ChangeDate"].Value = obj.ChangeDate;
        //            sqlCom.Parameters["@ChangeUser"].Value = obj.ChangeUser;

        //            return sqlCom;
        //        }
    }
}
