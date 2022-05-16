using APIInformationRetriever.Models.Classes.Responses;
using System.Reflection;
using System.Text;

namespace FileWritter
{
    public class Writer
    {
        public string PathStr { get; set; } = Directory.GetCurrentDirectory();
        public string FileName { get; set; }
        public IResponse Response { get; set; }
        public Writer(IResponse Response, string FileName)
        {
            this.FileName = FileName;
            this.Response = Response;
        }

        public string WriteResponses()
        {
            switch (Response)
            {
                case QuoteResponse res:
                    return WriteResponses(res.QuoteResults);
                case SparkResponse res:
                    break;
                case QuoteSummaryResponse res:
                    break;
                default:
                    throw new ArgumentException("This response is not supported at the moment");
            }
            return string.Empty;
        }

        private string WriteResponses(List<QuoteResult> results)
        {
            Type t = results[0].GetType();
            PropertyInfo[] Props = t.GetProperties();
            FileName += FileName + DateTime.Now.ToString("yyyy-MM-dd") + ".csv";
            using (StreamWriter sr = new StreamWriter(Path.Combine(PathStr, FileName)))
            {
                var line = String.Join(',', Props.Select(p => p.Name).ToArray());
                sr.WriteLine(line);
                foreach(var result in results)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (PropertyInfo prop in Props)
                    {
                        if (prop.GetValue(result) != null)
                            sb.Append(prop.GetValue(result).ToString().Replace(',', '-'));
                        else
                            sb.Append("");

                        sb.Append(",");
                    }
                    sb.Remove(sb.Length - 1, 1);
                    sr.WriteLine(sb.ToString());
                }
            }
            return Path.Combine(PathStr, FileName);
        }

        public void DeleteFile() =>
            File.Delete(PathStr);
    }
}