﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using System.IO;
namespace EzBuy.classes
{
    public class Vp
    {
        public string name;
        public int value;
        public Vp(string name, int value)
        {
            this.name = name;
            this.value = value;
        }
    }

    public class aws
    {
        AmazonDynamoDBClient client = new AmazonDynamoDBClient();
        Table table;
        Table table2;
        public aws()
        {
            table = Table.LoadTable(client, "esqz");
            table2 = Table.LoadTable(client, "oneitest");
        }
        public Document getItem(int id, GetItemOperationConfig c)
        {
            return table.GetItem(id);
        }
        public Document getItem2(int id,GetItemOperationConfig c)
        {
            return table2.GetItem(id);
        }
        public void pullToAWS2(int id, List<Vp> sp)
        {
            Document chainStore2 = new Document();
            chainStore2["id"] = id;
            foreach (Vp vp in sp)
            {
                chainStore2[vp.name] = vp.value;
            }
            table2.PutItem(chainStore2);
        }
        public void pullToAWS_ezstockquote(int sn, List<Vp> sp)
        {
            Document chainStore2 = new Document();
            chainStore2["sn"] = sn;
            foreach (Vp vp in sp)
            {
                chainStore2[vp.name] = vp.value;
            }
            table.PutItem(chainStore2);
        }
        public void pullToAWS(int sn, int sph)
        {
            Document chainStore2 = new Document();
            chainStore2["sn"] = sn;
            chainStore2["sph"] = sph;
            table.PutItem(chainStore2);
        }
        public string startLine()
        {
//            Table table = Table.LoadTable(client, "esqz");
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(@"C:\Users\sam.mak\Documents\Visual Studio 2010\Projects\StockMaximumGain\StockMaximumGain\StockMaximumGain\snsph.txt"))
                {
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {                       
                        if (!line.Equals(""))
                        {
                            int sn = -1;
                            int sph = -1;
                            sn = Convert.ToInt32(line.Split(',')[0]);
                            sph = Convert.ToInt32(line.Split(',')[1]);
                            if (sph > 0)
                            {
                                Document chainStore2 = new Document();
                                chainStore2["sn"] = sn;
                                chainStore2["sph"] = sph;
                                table.PutItem(chainStore2);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                String x = e.Message;
            }
            return "";
        }
    }
}
