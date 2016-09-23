using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ozoneserviceapp
{
    public partial class testpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            Response.Write(id);

           
        
               /* if (distance == 1)
                {
                    total = 35;
                }
                if ((distance - 10) > 1 && (distance - 10) <= 10)
                {
                    total = total + ((distance - 1) * 2);
                }
                if ((distance-20) < 20)
                {
                    
                    total = total + ((distance - 10) * 4);
                }

                else if (distance > 20)
                {
                    total = total + ((distance - 20) * 6);
                }

                if (distance > 30)
                {
                    total = total + ((distance - 30) * 8);
                }

                if (distance > 45)
                {
                    total = total + ((distance - 45) * 10);
                }

            */
            int total = 35;
            int rate = 0;            
            int distance = 45;

                for (int i = 1; distance >= 1;i++ )
                {
                    if (i == 1){ /* 1 km*/
                        rate = 35;                       
                        total = rate;
                        distance = distance - 1;
                        rate = 2;
                    }
                    else if (i == 2 && distance >=9){ /*2 - 10 km*/                       
                        total = total + ((9) * rate);
                        distance = distance - 9;
                        rate = 4;
                    }
                    else if (i ==3 && distance >=10){ /*11 - 20 km*/                       
                        total = total + ((10) * rate);
                        distance = distance - 10;
                        rate = 6;
                    }
                    else if (i == 4 && distance >=10){  /*21 - 30 km*/                        
                        total = total + ((10) * rate);
                        distance = distance - 10;
                        rate = 8;
                    }
                    else if (i == 5 && distance >=15) /*31 - 45 km*/
                    {                        
                        total = total + ((15) * rate);
                        distance = distance - 15;
                        rate = 10;
                    }
                    else if (i == 6) /*46+ km*/
                    {                        
                        total = total + ((distance) * 10);
                        distance = 0;
                        
                    }
                    else
                    {
                        total = total + ((distance) * rate);
                        distance = 0;
                    }                                                        
                                    }
                Response.Write(total);




        }
    }
}