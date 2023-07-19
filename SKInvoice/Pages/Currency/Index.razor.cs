using SKInvoice.Data;
using SKInvoice.Data.Obj;
using Dapper;
using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;
using System.Data.SqlClient;

namespace SKInvoice.Pages.Currency
{
	partial class Index : ComponentBase
	{
		[Inject]
		private IDatabaseConnection? DbConnection { get; set; }
		public IEnumerable<CurrencyCls>? CurrencyList { get; set; }
		public CurrencyCls CurrencyToEdit { get; set; } = new();
		public bool IsEditModalOpen = false;
		public bool IsDeleteModalOpen = false;
		public int cnt = 1;

		public async Task GetCurrencies(SqlConnection connection)
		{
			string sql = @"SELECT * FROM Currencies";
			CurrencyList = await connection.QueryAsync<CurrencyCls>(sql);
		}

		protected override async Task OnInitializedAsync()
		{
			cnt = 1;
			if (DbConnection != null)
			{
				using SqlConnection connection = DbConnection.GetConnection();
				await GetCurrencies(connection);
			}
			else
				Console.WriteLine("Database Connection Error!");
		}

		private async Task EditCurrency()
		{
			try
			{
				if(DbConnection != null)
				{
					using SqlConnection connection = DbConnection.GetConnection();
					//await connection.UpdateAsync(CurrencyToEdit);
					await GetCurrencies(connection);
				}
				else
					Console.WriteLine("Database Connection Error!");
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
		private async Task DeleteCurrency()
		{
			try
			{
				if(DbConnection != null)
				{
					using SqlConnection connection = DbConnection.GetConnection();
					//await conn.DeleteAsync(MovieToUpdate);
					await GetCurrencies(connection);
					IsDeleteModalOpen = false;
				}
				else
					Console.WriteLine("Database Connection Error!");

			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		private async Task ShowEditModal(Guid Id)
		{

			if(DbConnection != null)
			{
				using SqlConnection connection = DbConnection.GetConnection();
				//CurrencyToEdit = await connection.QueryFirstOrDefaultAsync<CurrencyCl>(@"select M.* ,C.NAME as COUNTRYNAME ,G.NAME AS GENRENAME ,L.NAME AS LANGUAGENAME from MOVIE M inner join COUNTRY C ON M.COUNTRYID=C.ID inner join GENRE G ON M.GENREID=G.ID inner join LANGUAGES L ON M.LANGUAGEID=L.ID and M.Id=@Id", new { Id });
				IsEditModalOpen = true;
			}
			else
				Console.WriteLine("Database Connection Error!");
		}

		private void HideEditModal()
		{
			IsEditModalOpen = false;
		}

		private async Task ShowDeleteModal(Guid Id)
		{
			if(DbConnection != null)
			{
				using SqlConnection connection = DbConnection.GetConnection();
				//MovieToUpdate = await conn.QueryFirstOrDefaultAsync<MOVIE>(@"select M.* ,C.NAME as COUNTRYNAME ,G.NAME AS GENRENAME ,L.NAME AS LANGUAGENAME from MOVIE M inner join COUNTRY C ON M.COUNTRYID=C.ID inner join GENRE G ON M.GENREID=G.ID inner join LANGUAGES L ON M.LANGUAGEID=L.ID and M.Id=@Id", new { Id });
				IsDeleteModalOpen = true;
			}
			else
				Console.WriteLine("Database Connection Error!");
		}

		private void HideDeleteModal()
		{
			IsDeleteModalOpen = false;
		}
	}
}
