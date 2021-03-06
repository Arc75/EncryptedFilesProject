using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;
using SecuredFilesProject.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SecuredFilesProject.Infrastructure.Models
{
    public class BaseRepository : IRepository, IDisposable
    {
        private static BaseRepository instance;

        public static IRepository GetContext()
        {
            if (instance == null)
                instance = new BaseRepository();

            return instance;
        }

        protected static Firebase.Database.FirebaseClient _firebaseContext;
        //protected static FirestoreDb _context;
        protected static Firebase.Auth.FirebaseAuthProvider _auth;
        private string FirebaseToken = "";
        private string RefreshToken = "";

        protected BaseRepository()
        {
            var connection = "https://dfiles-f71a3-default-rtdb.europe-west1.firebasedatabase.app/";
            var webApiKey = "AIzaSyAq65qvj-HATRr2bJrNFOW3HK0gOZ7YK78";

            _firebaseContext = new Firebase.Database.FirebaseClient(connection);
            _auth = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
        }

        protected BaseRepository(FirebaseClient context)
        {
            _firebaseContext = context;
        }

        public async Task<IModel> CreateUserWithPasswordAsync(IModel obj)
        {
            var user = (ILoginModel)obj;

            var result = await _auth.CreateUserWithEmailAndPasswordAsync(user.Email, user.Password);

            return obj;
        }

        public async Task<IModel> AuthorizeAsync(IModel obj)
        {
            var user = (ILoginModel)obj;

            var result = await _auth.SignInWithEmailAndPasswordAsync(user.Email, user.Password);

            //todo check 2fa

            return obj;
        }

        public async Task<bool> Add(IModel obj)
        {
            var postRequest = JsonConvert.SerializeObject(obj);

            var result = await _firebaseContext.Child($"{obj.GetType().Name}/").Child(obj.Id.ToString()).PostAsync(postRequest);

            return string.IsNullOrEmpty(result.Key);
        }

        public async Task<IModel> GetAsync<T>(int id)
        {
            var result = await _firebaseContext.Child($"{typeof(T).Name}").Child(id.ToString()).OnceAsync<T>();
            return (IModel)result.FirstOrDefault().Object;
        }

        public Task<bool> ExistsAsync(Expression<Func<IModel, bool>> whereClause)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<IModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<IModel>> GetAllAsync(Expression<Func<IModel, bool>> whereClause)
        {
            throw new NotImplementedException();
        }

        public Task<List<IModel>> GetAllSortedAsync(Expression<Func<IModel, int>> orderBy)
        {
            throw new NotImplementedException();
        }

        public Task<List<IModel>> GetAllSortedAsync(Expression<Func<IModel, bool>> whereClause, Expression<Func<IModel, int>> orderBy)
        {
            throw new NotImplementedException();
        }

        public Task<IModel> GetFirstAsync(Expression<Func<IModel, bool>> whereClause)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _firebaseContext.Dispose();
        }
    }
}
