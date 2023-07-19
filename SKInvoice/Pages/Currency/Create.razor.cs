using Dapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.Extensions;
using SKInvoice.Data;
using SKInvoice.Data.Obj;
using System;
using System.Data.SqlClient;


namespace SKInvoice.Pages.Currency
{
	partial class Create : ComponentBase
	{
		[Inject]
		private IDatabaseConnection? DbConnection { get; set; }
		public CurrencyCls CurrencyToCreate { get; set; } = new();

		public async Task CreateCurrency()
		{
			try
			{
				if (DbConnection != null)
				{
					using SqlConnection connection = DbConnection.GetConnection();
					string sql = @"INSERT INTO Currencies(Id, Name, Symbol) VALUES(newid(), @name, @symbol)";
					await connection.ExecuteAsync(sql, new { name = CurrencyToCreate.Name, symbol = CurrencyToCreate.Symbol});
				}
				else
					Console.WriteLine("Database connection error!");
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
