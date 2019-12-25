using CsvHelper;
using ApiWanet01FieldService01.XmlToObject;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using static ApiWanet01FieldService01.XmlToObject.RootXML;

namespace ApiWanet01FieldService01.CSV
{
        class CSVConvertByServicos
        {
            public List<KeyValuePair<int, string>> headersRow = new List<KeyValuePair<int, string>>();
            public List<KeyValuePair<int, string>> headersOS = new List<KeyValuePair<int, string>>();
            public List<ExpandoObject> objRows = new List<ExpandoObject>();
            public List<ExpandoObject> objOsRows = new List<ExpandoObject>();
            public void execute(string dataCSV)
            {
                addRow(dataCSV);
            }
            public List<KeyValuePair<int, string>> loadHeader(string csvHeader)
            {
                List<KeyValuePair<int, string>> headers = new List<KeyValuePair<int, string>>();

                TextReader sr = new StringReader(csvHeader);

                var csv = new CsvReader(sr);

                var cont = 0;

                csv.Read();

                while (true)
                {
                    try
                    {
                        headers.Add(new KeyValuePair<int, string>(cont, csv[cont]));
                        cont++;
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }

                if (headers == null)
                {
                    Environment.Exit(0);
                }

                return headers;
            }
            private void addRow(string dataCSV)
            {
                TextReader sr = new StringReader(dataCSV);

                var csv = new CsvReader(sr);

                csv.Read();

                dynamic data = new ExpandoObject();

                IDictionary<string, object> dictionary = (IDictionary<string, object>)data;


                foreach (var header in headersRow)
                {
                    try
                    {
                        dictionary.Add(header.Value, csv[header.Key]);

                    }
                    catch (Exception)
                    {
                        continue;
                    }

                }


                dictionary.Add("list_os", objOsRows);

                objRows.Add(data);
            }
            public void excuteos_s(string xmlDataOS)
            {
                objOsRows = new List<ExpandoObject>();

                WebData os = ReadXmlParseObj.Deserialize<WebData>(xmlDataOS);
                var pOS = os.WebTable[7];
                headersOS = loadHeader(pOS.Head);

                foreach (var oss in pOS.Rows.Row)
                {
                    try
                    {
                        addRowOs(oss);
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                }
            }
            private void addRowOs(string dataCSV)
            {

                TextReader sr = new StringReader(dataCSV);

                var csv = new CsvReader(sr);

                csv.Read();

                dynamic data = new ExpandoObject();

                IDictionary<string, object> dictionary = (IDictionary<string, object>)data;

                foreach (var header in headersOS)
                {
                    try
                    {
                        dictionary.Add(header.Value, csv[header.Key]);
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                }

                objOsRows.Add(data);
            }
        }
    }
