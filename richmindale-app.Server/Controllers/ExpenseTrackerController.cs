using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using richmindale_app.Server.Models.ViewModels;
using richmindale_app.Server.Models.ViewModels.ExpenseTracker;
using richmindale_app.Server.Repositories;

namespace richmindale_app.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseTrackerController : ControllerBase
    {

        private readonly IExpenseTrackerRepository service;

        public ExpenseTrackerController(IExpenseTrackerRepository _service)
        {
            service = _service;
        }

        [HttpPost]
        [Route("AuthenticateUser")]
        public async Task<JsonResult> AuthenticateUser(string? username, string? password)
        {
            try
            {
               object user =  await service.AuthenticateUser(username, password);
               if(user != null) 
               {
                    return new JsonResult(new {status = "success", info = user, msg = "Successfully authenticated"}, new JsonSerializerOptions());
               }
               else
               {
                    return new JsonResult(new {status = "error", msg = "Invalid username/password"}, new JsonSerializerOptions());
               }
            }
            catch(Exception ex)
            {
                return new JsonResult(new {status = "error", msg = "An error occured while authenticating admin. ERROR: " + ex.Message.ToString()}, new JsonSerializerOptions());
            }
        }

        [HttpGet]
        [Route("LoadSetupTables")]
        public async Task<JsonResult> LoadSetupTables(string? table)
        {
            return new JsonResult(new {data = await service.LoadSetupTables(table)}, new JsonSerializerOptions());
        }

        [HttpPost]
        [Route("SaveSetupItems")]
        public async Task<JsonResult> SaveSetupItems(string? table, int? id, string? code, string? value)
        {
            try
            {
                await service.SaveSetupItems(table, id, code, value);
                return new JsonResult(new {status = "success",  msg = "Item successfully added."}, new JsonSerializerOptions());
            }
            catch(Exception ex)
            {
                return new JsonResult(new {status = "error", msg = "An error occured while saving " + table + ". ERROR: " + ex.Message.ToString()}, new JsonSerializerOptions());
            }
        }

        [HttpPost]
        [Route("DeleteSetupItems")]
        public async Task<JsonResult> DeleteSetupItems(string? table, int id)
        {
            try
            {
                await service.DeleteSetupItems(table, id);
                return new JsonResult(new {status = "success", msg = "Item successfully deleted."}, new JsonSerializerOptions());
            }
            catch(Exception ex)
            {
                return new JsonResult(new {status = "error", msg = "Unable to delete selected item due to error. ERROR: " + ex.Message.ToString()}, new JsonSerializerOptions());
            }
        }

        [HttpGet]
        [Route("GetLocations")]
        public async Task<JsonResult> GetLocations()
        {
            return new JsonResult(await service.GetLocations(), new JsonSerializerOptions());
        }

        [HttpPost]
        [Route("AddLocation")]
        public async Task<JsonResult> AddLocation(string? LocationName)
        {
            try
            {
                int Id = await service.AddLocation(LocationName);
                if(Id != 0)
                {
                    return new JsonResult(new {status = "success", LocationId = Id, msg = "Location successfully added."}, new JsonSerializerOptions());
                }
                else
                {
                    return new JsonResult(new {status = "error", msg = "Unable to add Location!"}, new JsonSerializerOptions());
                }
            }
            catch(Exception ex)
            {
                return new JsonResult(new {status = "error", msg = "An error occured: " + ex.Message.ToString()});
            }
        }

        [HttpGet]
        [Route("GetActivities")]
        public async Task<JsonResult> GetActivities()
        {
            return new JsonResult(await service.GetActivities(), new JsonSerializerOptions());
        }

        [HttpPost]
        [Route("AddActivity")]
        public async Task<JsonResult> AddActivity(string? ActivityName)
        {
            try
            {
                int Id = await service.AddActivity(ActivityName);
                if(Id != 0)
                {
                    return new JsonResult(new {status = "success", ActivityId = Id, msg = "Activity successfully added."}, new JsonSerializerOptions());
                }
                else
                {
                    return new JsonResult(new {status = "error", msg = "Unable to add ActivityName!"}, new JsonSerializerOptions());
                }
            }
            catch(Exception ex)
            {
                return new JsonResult(new {status = "error", msg = "An error occured: " + ex.Message.ToString()});
            }
        }

        [HttpGet]
        [Route("GetAssets")]
        public async Task<JsonResult> GetAssets()
        {
            return new JsonResult(await service.GetAssets(), new JsonSerializerOptions());
        }

        [HttpPost]
        [Route("AddAsset")]
        public async Task<JsonResult> AddAsset(string? AssetName)
        {
            try
            {
                int Id = await service.AddAsset(AssetName);
                if(Id != 0)
                {
                    return new JsonResult(new {status = "success", AssetId = Id, msg = "Asset successfully added."}, new JsonSerializerOptions());
                }
                else
                {
                    return new JsonResult(new {status = "error", msg = "Unable to add Asset!"}, new JsonSerializerOptions());
                }
            }
            catch(Exception ex)
            {
                return new JsonResult(new {status = "error", msg = "An error occured: " + ex.Message.ToString()});
            }
        }

        [HttpGet]
        [Route("GetBanks")]
        public async Task<JsonResult> GetBanks()
        {
            return new JsonResult(await service.GetBanks(), new JsonSerializerOptions());
        }

        [HttpPost]
        [Route("AddBank")]
        public async Task<JsonResult> AddBank(string? BankCode, string? BankName)
        {
            try
            {
                int Id = await service.AddBank(BankCode, BankName);
                if(Id != 0)
                {
                    return new JsonResult(new {status = "success", BankId = Id, msg = "Bank successfully added."}, new JsonSerializerOptions());
                }
                else
                {
                    return new JsonResult(new {status = "error", msg = "Unable to add Bank!"}, new JsonSerializerOptions());
                }
            }
            catch(Exception ex)
            {
                return new JsonResult(new {status = "error", msg = "An error occured: " + ex.Message.ToString()});
            }
        }

        [HttpGet]
        [Route("GetBankAccounts")]
        public async Task<JsonResult> GetBankAccounts()
        {
            return new JsonResult(await service.GetBankAccounts(), new JsonSerializerOptions());
        }

        [HttpGet]
        [Route("GetBankAccountDetails")]
        public async Task<JsonResult> GetBankAccountDetails(int id)
        {
            return new JsonResult(await service.GetBankAccountDetails(id), new JsonSerializerOptions());
        }

        [HttpPost]
        [Route("AddBankAccount")]
        public async Task<JsonResult> AddBankAccount(BankAccountViewModel model)
        {
            try
            {
                await service.AddBankAccount(model);
                return new JsonResult(new {status = "success", msg = "Bank Account successfully added." }, new JsonSerializerOptions());
            }
            catch(Exception ex)
            {
                return new JsonResult(new {status = "error", msg = "An error occured while saving Bank Account details. ERROR: " + ex.Message.ToString()}, new JsonSerializerOptions());
            }
        }

        [HttpPost]
        [Route("LoadPaginatedBankAccounts")]
        public async Task<JsonResult> LoadPaginatedBankAccounts(FilterViewModel model)
        {
            return new JsonResult(new {data  = await service.LoadPaginatedBankAccounts(model)}, new JsonSerializerOptions());
        }

        [HttpGet]
        [Route("LoadBankAccounts")]
        public async Task<JsonResult> LoadBankAccounts()
        {
            return new JsonResult(new {data = await service.LoadBankAccounts()}, new JsonSerializerOptions());
        }

        [HttpPost]
        [Route("DeleteBankAccount")]
        public async Task<JsonResult> DeleteBankAccount(int id)
        {
            try
            {
                await service.DeleteBankAccount(id);
                return new JsonResult(new {status = "success", msg = "Selected Bank Account successfully deleted."}, new JsonSerializerOptions());
            }
            catch(Exception ex)
            {
                return new JsonResult(new {status = "error", msg = "An error occur while deleting Bank Account. ERROR: " + ex.Message.ToString()}, new JsonSerializerOptions());
            }
        }

        [HttpGet]
        [Route("GetCurrencies")]
        public async Task<JsonResult> GetCurrencies()
        {
            return new JsonResult(await service.GetCurrencies(), new JsonSerializerOptions());
        }

        [HttpGet]
        [Route("LoadExpenseMasterData")]
        public async Task<JsonResult> LoadExpenseMasterData(Guid id)
        {
            return new JsonResult(new {data = await service.LoadExpenseMasterData(id)}, new JsonSerializerOptions());
        }

        [HttpPost]
        [Route("LoadPaginatedExpense")]
        public async Task<JsonResult> LoadPaginatedExpense(ExpenseFilterViewModel model)
        {
            return new JsonResult(new {data = await service.LoadPaginatedExpense(model)}, new JsonSerializerOptions());
        }

        [HttpGet]
        [Route("GetExpenseDetails")]
        public async Task<JsonResult> GetExpenseDetails(Guid id)
        {
            return new JsonResult(await service.GetExpenseDetails(id), new JsonSerializerOptions());
        }

        [HttpPost]
        [Route("SaveExpenseTransaction")]
        public async Task<JsonResult> SaveExpenseTransaction(ExpenseViewModel model)
        {
            try
            {
                await service.SaveExpenseTransaction(model);
                return new JsonResult(new {status = "success", msg = "Transaction successfully added."},  new JsonSerializerOptions());
            }
            catch(Exception ex)
            {
                return new JsonResult(new {status = "error", msg = "An error occured: " + ex.Message.ToString()});
            }
        }

        [HttpPost]
        [Route("DeleteExpenseTransaction")]
        public async Task<JsonResult> DeleteExpenseTransaction(Guid id)
        {
            try
            {
                await service.DeleteExpenseTransaction(id);
                return new JsonResult(new {status = "success", msg = "Transaction successfully deleted."},  new JsonSerializerOptions());
            }
            catch(Exception ex)
            {
                return new JsonResult(new {status = "error", msg = "An error occured: " + ex.Message.ToString()});
            }
        }

        [HttpGet]
        [Route("LoadUsers")]
        public async Task<JsonResult> LoadUsers()
        {
            return new JsonResult(new {data = await service.LoadUsers()}, new JsonSerializerOptions());
        }

        [HttpPost]
        [Route("LoadPaginatedUsers")]
        public async Task<JsonResult> LoadPaginatedUsers(FilterViewModel model)
        {
            return new JsonResult(new {data = await service.LoadPaginatedUsers(model)}, new JsonSerializerOptions());
        }

        [HttpGet]
        [Route("GetUserDetails")]
        public async Task<JsonResult> GetUserDetails(Guid id)
        {
            return new JsonResult(await service.GetUserDetails(id), new JsonSerializerOptions());
        }

        [HttpGet]
        [Route("GetRoles")]
        public async Task<JsonResult> GetRoles()
        {
            return new JsonResult(await service.GetRoles(), new JsonSerializerOptions());
        }

        [HttpPost]
        [Route("SaveUserDetails")]
        public async Task<JsonResult> SaveUserDetails(UsersViewModel model)
        {
            try
            {
                return new JsonResult(new {status = "success", UserId = await service.SaveUserDetails(model)}, new JsonSerializerOptions());
            }
            catch(Exception ex)
            {
                return new JsonResult(new {status = "error", msg = "Unable to save user details due to error. ERROR: " + ex.Message.ToString()}, new JsonSerializerOptions());
            }
        }

        [HttpPost]
        [Route("DeactivateUser")]
        public async Task<JsonResult> DeactivateUser(Guid id)
        {
            try
            {
                await service.DeactivateUser(id);
                return new JsonResult(new {status = "success", msg = "User successfully deactivated."}, new JsonSerializerOptions());
            }
            catch(Exception ex)
            {
                return new JsonResult(new {status = "error", msg = "Unable to update user status due to error. ERROR: " + ex.Message.ToString()}, new JsonSerializerOptions());
            }
        }

        [HttpPost]
        [Route("SaveUserProfile")]
        public async Task<JsonResult> SaveUserProfile(UsersViewModel model)
        {
            try
            {
                await service.SaveUserProfile(model);
                return new JsonResult(new {status = "success", msg = "Your profile successfully updated."}, new JsonSerializerOptions());
            }
            catch(Exception ex)
            {
                return new JsonResult(new {status = "error", msg = "Unable to save user profile due to error. ERROR: " + ex.Message.ToString()}, new JsonSerializerOptions());
            }
        }

        [HttpPost]
        [Route("SendResetRequest")]
        public async Task<JsonResult> SendResetRequest(string? username, string? email)
        {
            return new JsonResult(new {status = await service.SendResetRequest(username, email)}, new JsonSerializerOptions());
        }

        [HttpPost]
        [Route("ResetPassword")]
        public async Task<JsonResult> ResetPassword(Guid id, string? password)
        {
            try
            {
                await service.ResetPassword(id, password);
                return new JsonResult(new {status = "success", msg = "Password successsfully updated."}, new JsonSerializerOptions());
            }
            catch(Exception ex)
            {
                return new JsonResult(new {status = "error", msg = "An error occured while resetting your password. ERROR: " + ex.Message.ToString()}, new JsonSerializerOptions());
            }
        }

        [HttpGet]
        [Route("LoadMonthlyDebit")]
        public async Task<JsonResult> LoadMonthlyDebit(Guid id, int? month)
        {
            return new JsonResult(await service.LoadMonthlyDebit(id,month), new JsonSerializerOptions());
        }

        [HttpGet]
        [Route("LoadMonthlyCredit")]
        public async Task<JsonResult> LoadMonthlyCredit(Guid id, int? month)
        {
            return new JsonResult(await service.LoadMonthlyCredit(id,month), new JsonSerializerOptions());
        }

        [HttpGet]
        [Route("LoadYearlyDashboard")]
        public async Task<JsonResult> LoadYearlyDashboard(Guid id, int? year)
        {
            return new JsonResult(new {data = await service.LoadYearlyDashboard(id, year)}, new JsonSerializerOptions());
        }


    }
}
