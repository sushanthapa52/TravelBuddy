using Firebase.Auth;
using Firebase.Auth.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBuddy.Service
{
    public class FirebaseAuthentication
    {
        private readonly FirebaseAuthClient _authClient;

        public FirebaseAuthentication(FirebaseAuthClient authClient)
        {
            _authClient = authClient;
        }

        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            try
            {
                var userCredential = await _authClient.SignInWithEmailAndPasswordAsync(email, password);
                //var userID = userCredential.User.Uid;

                return userCredential.User.Uid;
                //return userCredential.User?.GetIdTokenAsync().ToString();
            }
            catch (Exception ex)
            {
                // Handle error
                return null;
            }
        }

        public async Task<string> RegisterWithEmailPassword(string email, string password)
        {
            try
            {
                var userCredential = await _authClient.CreateUserWithEmailAndPasswordAsync(email, password);
                return userCredential.User?.GetIdTokenAsync().ToString();
            }
            catch (Exception ex)
            {
                // Handle error
                return null;
            }
        }
    }
}
