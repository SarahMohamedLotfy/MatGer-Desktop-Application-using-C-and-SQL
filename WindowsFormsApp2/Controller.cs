using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class Controller
    {
        DBManager dbMan;
        int sender;

        public Controller()
        {
            dbMan = new DBManager();
        }

        //=======================================================================================================================//
        //                                                      Sofyan                                                           //
        //=======================================================================================================================//

        public int InsertCustomer(string UserName , string Fname , string Lname , string Pass )       // Insert The customer
        {
            string query = "INSERT INTO Customer(username , Fname , Lname , Pass) values ('"+UserName+"' , '"+Fname+"' , '"+Lname+"' , '"+Pass+"')";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable GetMessages(int customer, int seller)
        {
            string query = "select* from Talk t ,message m where m.IDMessage=t.IDMessage AND t.IDSeller = " + seller+" AND t.IDCustomer = "+customer+ "order by DateMessage" ;
            return dbMan.ExecuteReader(query);
        }
        public DataTable GetConversationsForSeller( int seller)
        {
            string query = "select c.IDCustomer , c.Fname from Talk t  ,Customer c  where  t.IDSeller = " + seller +" AND t.IDCustomer = c.IDCustomer group by c.IDCustomer , c.Fname";
            return dbMan.ExecuteReader(query);
        }
        public DataTable GetConversationsForCustomer(int customer)
        {
            string query = "select c.IDseller , c.Fname from Talk t  ,seller c  where  t.IDcustomer = " + customer + " AND t.IDseller = c.IDseller group by c.IDseller , c.Fname";
            return dbMan.ExecuteReader(query);
        }
        public DataTable GetCommentsForProduct(int product)
        {
            string query = "select m.[Content],c.Fname,m.DateComment from Comment m, Customer c,CommentUser u where u.IDComment=m.IDComment AND u.IDCustomer= c.IDCustomer AND u.IDProduct= "+product+";";
            return dbMan.ExecuteReader(query);
        }

        public int sendMessage(int customer, int seller, int type, string message)
        {
           


            int result2 = insertNotification(0, message,  seller, customer);

            string query = "insert into message(text,IDNotification) values  ( '" + message + "',(select max(IDNotification) from Notification));" +
            "insert into Talk values  (" + seller + "," + customer + ", (select max(IDMessage) from message)," + type + ")";


            return dbMan.ExecuteNonQuery(query);
        }

        public int InsertSeller(string UserName, string Fname, string Lname, string Pass, string Phone)  // Insert the seller
        {
            string query = "INSERT INTO Seller(username , Fname , Lname , Pass , PhoneNumber) values ('" + UserName + "' , '" + Fname + "' , '" + Lname + "' , '" + Pass + "' , '" + Phone + "')";
            return dbMan.ExecuteNonQuery(query);
        }
        public int addComment(int iD, int iDProduct, string comment)
        {
            int ids = (int)getIDSellerFromProduct(iDProduct);
            
          
                int result1 = insertNotification(1, comment,  ids, iD);

            string query = "insert into Comment([Content],IDNotification) values ('" + comment + "',(select max(IDNotification) from Notification)); insert into CommentUser values(" + iDProduct + ",(select max(IDComment)from Comment)," + iD + "); ";



            return dbMan.ExecuteNonQuery(query);
        }

        //Login
        public object GetCustomer(string UserName , string Pass)                                         // Get the id of the customer
        {
            string query = "select IDCustomer from Customer where username = '" + UserName + "' and pass = '" + Pass + "' ";
            if (dbMan.ExecuteScalar(query) != null)
                return dbMan.ExecuteScalar(query);
            else
                return 0;
        }
        public object GetSeller(string UserName, string Pass)                                            // Get the id of the seller
        {
            string query = "select IDSeller from Seller where username = '" + UserName + "' and pass = '" + Pass + "';";
            if (dbMan.ExecuteScalar(query) != null)
                return dbMan.ExecuteScalar(query);
            else
                return 0;
        }
        public DataTable GetName(int ID)                                                                 // Get the name of the customer
        {
            string query = "select Fname , Lname from Customer where Customer_ID = "+ID+";";
            return dbMan.ExecuteReader(query);
        }
        public int DeleteCustomer(int ID)                                                                // Delete the customer
        {
            string query = "delete Customer where IDCustomer = "+ID+";";
            return dbMan.ExecuteNonQuery(query);
        }
        public int DeleteSeller(int ID)                                                                   // Delete the seller
        {
            string query = "delete Seller where IDSeller = " + ID + ";";
            return dbMan.ExecuteNonQuery(query);
        }
        public int ChangePasswordCustomer(string OldPassword , string NewPassword , int ID)               // Change the password of the customer
        {
            string query = "Update Customer set pass = '"+NewPassword+"' where pass = '"+OldPassword+"' and IDCustomer = "+ID+"";
            return dbMan.ExecuteNonQuery(query);
        }



        public int ChangeUserNameCustomer(string Password, string UserName, int ID)                       // Change the username of the customer
        {
            string query = "Update Customer set username = '" + UserName + "' where pass = '" + Password + "' and IDCustomer = " + ID + "";
            return dbMan.ExecuteNonQuery(query);
        }

        public int ChangePasswordSeller(string OldPassword, string NewPassword, int ID)                   // Change the password of the seller
        {
            string query = "Update Seller set pass = '" + NewPassword + "' where pass = '" + OldPassword + "' and IDSeller = " + ID + "";
            return dbMan.ExecuteNonQuery(query);
        }

        public int ChangeUserNameSeller(string Password, string UserName, int ID)                         // Change the username of the seller
        {
            string query = "Update Seller set username = '" + UserName + "' where pass = '" + Password + "' and IDSeller = " + ID + "";
            return dbMan.ExecuteNonQuery(query);
        }
        public DataTable GetNameCustomer(int ID)                                                          // Get name of the customer
        {
            string query = "select Fname , Lname from Customer where IDCustomer = "+ID+";";
            return dbMan.ExecuteReader(query);
        }
        public DataTable GetNameSeller(int ID)                                                          // Get name of the customer
        {
            string query = "select Fname , Lname from Seller where IDSeller = " + ID + ";";
            return dbMan.ExecuteReader(query);
        }
        public DataTable GetAllCategory()
        {
            string query = "Select Name , IDCategory from Category ";
            return dbMan.ExecuteReader(query);
        }
        public int AddProduct(int Price , string Name, string Descrepction , int IDCategory , int IDSeller , string Path)
        {
            string query = "insert into Product(Price , Name , Descreption , IDCategory , IDSeller , Path) values (" + Price + " , '" + Name + "' , '" + Descrepction + "' , "+IDCategory+" , "+IDSeller+" , '"+Path+"');";
            return dbMan.ExecuteNonQuery(query);
        }
        public int IncreaseNumOfProduct(int ID)
        {
            string query = "Update Category set NumProducts =NumProducts+1 where IDCategory = " + ID + ";";
            return dbMan.ExecuteNonQuery(query);
        }

        public object GetImage()
        {
            string query = "select Path from Product where IDProduct = 1";
            string result = (string)(dbMan.ExecuteScalar(query));        // it return only 13 elements in the array
            return dbMan.ExecuteScalar(query);
        }
        public DataTable GetMyProducts(int ID)
        {
            string query = "Select * from Product where IDSeller = " + ID + ";";
            return dbMan.ExecuteReader(query);
        }
        public object GetPhone(int ID)
        {
            string query = "Select PhoneNumber from Seller where IDSeller = "+ID+"";
            return dbMan.ExecuteScalar(query);
        }
        public DataTable GetAllProducts()
        {
            string query = "Select * from Product ";
            return dbMan.ExecuteReader(query);
        }
        public int DeleteProduct(int ID)
        {
            string query = "Delete Product where IDProduct = "+ID+";";
            return dbMan.ExecuteNonQuery(query);
        }
        public int ChangePrice(int Price , int ID)
        {
            string query = "update Product set Price = "+Price+" where IDProduct = "+ID+"";
            return dbMan.ExecuteNonQuery(query);
        }
        public int ChangeDescreption(string D, int ID)
        {
            string query = "update Product set Descreption = '" + D + "' where IDProduct = " + ID + "";
            return dbMan.ExecuteNonQuery(query);
        }
        public object GetID()
        {
            string query = "select Max(IDSeller) from Seller";
            return dbMan.ExecuteScalar(query);
        }
        public object GetIDCustomer()
        {
            string query = "select Max(IDCustomer) from Customer";
            return dbMan.ExecuteScalar(query);
        }
        public DataTable GetProductByName(int ID)
        {
            string query = "Select * from Product where IDCategory = " + ID + " ;";
            return dbMan.ExecuteReader(query);
        }
        public DataTable GetProductByNameSeller(int ID , int ID_2)
        {
            string query = "Select * from Product where IDCategory = " + ID + " and IDSeller = "+ID_2+";";
            return dbMan.ExecuteReader(query);
        }
        public DataTable GetProductByNameAll(int ID)
        {
            string query = "Select * from Product where IDCategory = " + ID + ";";
            return dbMan.ExecuteReader(query);
        }
        public object CheckNameCustomer(string Name)
        {
            string query = "Select IDCustomer from Customer where username = '"+Name+"'";
            return dbMan.ExecuteScalar(query);
        }
        public object CheckNameSeller(string Name)
        {
            string query = "Select IDSeller from Seller where username = '" + Name + "'";
            return dbMan.ExecuteScalar(query);
        }
        public DataTable GetAllCustomer()
        {
            string query = "Select * from Customer where admin = 0";
            return dbMan.ExecuteReader(query);
        }
        public DataTable GetAllAdmins()
        {
            string query = "Select * from Customer where admin = 1";
            return dbMan.ExecuteReader(query);
        }
        public DataTable GetAllSeller()
        {
            string query = "Select * from Seller";
            return dbMan.ExecuteReader(query);
        }
        public DataTable GetAllCategory2()
        {
            string query = "Select * from Category";
            return dbMan.ExecuteReader(query);
        }
        public DataTable GetAllProduct()
        {
            string query = "Select * from Product";
            return dbMan.ExecuteReader(query);
        }
        public int RemoveCategory(int ID)
        {
            string query = "delete Category where IDCategory = " + ID + "";
            return dbMan.ExecuteNonQuery(query);
        }
        public int AddCategory(string Name)
        {
            string query = "Insert into Category(Name , NumProducts) values ('" + Name + "' , " + 0 + ")";
            return dbMan.ExecuteNonQuery(query);
        }
        public object CheckAdmin(int ID)
        {
            string query = "Select Admin from Customer where IDCustomer = " + ID + ";";
            return dbMan.ExecuteScalar(query);
        }
        public int UpdateNumProduct(int ID, int Num)
        {
            string query = "Update Category set NumProducts = " + Num + " where IDCategory = " + ID + "";
            return dbMan.ExecuteNonQuery(query);
        }
        public object GetNumOfProduct(int ID)
        {
            string query = "Select Count(*) From Product where IDCategory = " + ID + "";
            return dbMan.ExecuteScalar(query);
        }
        public int decreaseNumOfProduct(int ID)
        {
            string query = "Update Category set NumProducts = NumProducts-1 where IDCategory = " + ID + ";";
            return dbMan.ExecuteNonQuery(query);
        }
        public int InsertAdmin(string UserName, string Password , string FName, string LName)
        {
            string query = "INSERT INTO Customer(username , Pass , Admin  , Fname , Lname) values ('" + UserName + "' ,   '" + Password + "' , 1 , '"+FName+"' , '"+LName+"')";
            return dbMan.ExecuteNonQuery(query);
        }
        public object GetNumOfProduct2(int ID)
        {
            string query = "Select NumProducts from Category where IDCategory = "+ID+"";
            return dbMan.ExecuteScalar(query);
        }


        //=====================================================================================================================//
        //
        //=====================================================================================================================//



        //---------sarah mohamed ----------------//

        //total rate

        // Get Number of Rates of certain product
        public object getNoOfRatesOfproduct(int id)
        {
            string query = "select count(*) from Rate where IDProduct=  " + id + ";";
            // dbMan.ExecuteScalar(query);
            return dbMan.ExecuteScalar(query);
        }


        //Get Rate of certain product
        public object GetSumRate(int id)
        {
            string query = "Select  SUM(Rate) from Rate where IDProduct = " + id + ";";
            return dbMan.ExecuteScalar(query);////////////////

        }

        // put Ratetotal = zero if it is null
        public int putRatetotalZero(int id)
        {
            string query = "UPDATE Product SET " +
                "RateTotal = 0 WHERE IDProduct = " + id + ";";
            return dbMan.ExecuteNonQuery(query);
        }

        // update total rate in product  
        public int Updaterate(float rate, int id)
        {
            string query = "UPDATE Product SET " +
                "RateTotal = " + rate + "WHERE IDProduct = " + id + ";";
            return dbMan.ExecuteNonQuery(query);
        }

        // insert rate in rate table 

        public int Addrate(int productid, int idcustomer, int rate)
        {
            string query = "insert into Rate (IDProduct,IDCustomer,Rate) values (" + productid + " , " + idcustomer + " , " + rate + ");";
            return dbMan.ExecuteNonQuery(query);
        }
        //update the rate in rate table 
        public int updaterateinRatetable(int productid, int idcustomer, int rate)
        {
            string query = "UPDATE Rate SET " +
                "Rate = " + rate + "WHERE IDProduct = " + productid + "AND  IDCustomer =" + idcustomer + ";";
            return dbMan.ExecuteNonQuery(query);
        }
        public object GetCustomerID(int ID, int id)
        {
            string query = "select IDCustomer from Rate where IDCustomer = " + ID + " and IDProduct = " + id + "";
            return dbMan.ExecuteScalar(query);
        }
        public object GetTotalRate(int ID)
        {
            string query = "select RateTotal from Product where IDProduct = " + ID + ";";
            return dbMan.ExecuteScalar(query);
        }
        //  //////////////////////////////////////////////////

        //=====================================================================================================================//
        //--------------------------------------------------------sara yasser--------------------------------------------------//
        //=====================================================================================================================//

        public int insertNotification(int type, string cont,  int sid, int cid)
        {
            string query = "insert into Notification (type, [Content],  IDSeller, IDCustomer) values(" + type + ",'" + cont + "'," + sid + "," + cid + ");";
            return dbMan.ExecuteNonQuery(query);
        }

        
        //public DataTable getNotificationSM_2(int id)
        //{
        //    string query = "Select  type,f.DateNotification,f.[Content] from Notification f,Talk t,message m where f.IDNotification = m.IDNotification and m.IDMessage = t.IDMessage and t.Sender = 0 and f.IDSeller = " + id;
        //    return dbMan.ExecuteReader(query);
        //}
        public DataTable getNotificationSM(int id)
        {
            string query = "Select f.DateNotification,c.Fname from Notification f,Talk t,message m,Customer c where f.IDNotification = m.IDNotification and m.IDMessage = t.IDMessage and f.IDCustomer = c.IDCustomer and t.Sender = 0 and f.IDSeller = " + id;
            return dbMan.ExecuteReader(query);
        }
        //public DataTable getNotificationSC_2(int id)
        //{
        //    string query = "Select  f.type,f.DateNotification,f.[Content] from Notification f, Comment c where f.IDNotification = c.IDNotification and f.IDSeller = " + id;
        //    return dbMan.ExecuteReader(query);
        //}
        public DataTable getNotificationSC(int id)
        {
            string query = "Select  f.DateNotification,r.Fname, p.Name from Notification f, Comment c, Customer r, CommentUser u, Product p where f.IDNotification = c.IDNotification and r.IDCustomer = f.IDCustomer and p.IDProduct = u.IDProduct and u.IDComment = c.IDComment and f.IDSeller = " + id;
            return dbMan.ExecuteReader(query);
        }
        public object getIDSellerFromProduct(int pid)
        {
            string query = "select IDSeller from Product where IDProduct = " + pid;
            return dbMan.ExecuteScalar(query);
        }
        //public DataTable getNotificationC_2(int id)
        //{
        //   string query = "Select  f.DateNotification,f.[Content] from Notification f,Talk t,message m where f.IDNotification = m.IDNotification and m.IDMessage = t.IDMessage and t.Sender = 1 and  f.IDCustomer = " + id;
        //    return dbMan.ExecuteReader(query);
        // }
        public DataTable getNotificationC(int id)
        {
            string query = "Select  f.DateNotification,s.Fname from Notification f,Talk t,message m,Seller s where f.IDNotification = m.IDNotification and m.IDMessage = t.IDMessage and s.IDSeller = t.IDSeller and t.Sender = 1 and  f.IDCustomer = " + id;
            return dbMan.ExecuteReader(query);
        }
        public int getSenderType()
        {
            return sender;
        }
        public void setSenderType(int s)
        {
            sender = s;
        }
    }

}
