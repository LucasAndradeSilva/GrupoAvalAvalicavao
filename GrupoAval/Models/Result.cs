namespace GrupoAval.Models
{
    public class Result
    {	
		public Result(dynamic data, bool success = true)
        {
            if (data is null && !success)
            {
                data = "Ocorreu um erro";
            }
            else
            {
                Data = data;
                Success = success;
            }            
        }

        public dynamic Data { get; set; }        
        public bool Success { get; set; }
    }
}
