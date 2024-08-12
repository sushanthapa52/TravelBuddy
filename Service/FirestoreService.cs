using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using Google.Cloud.Firestore;
using TravelBuddy.Entities;


namespace TravelBuddy.Service
{
    public class FirestoreService
    {
        //private readonly FirebaseClient _firebaseClient;

        //public FirestoreService(string databaseUrl, string authToken)
        //{
        //    _firebaseClient = new FirebaseClient(databaseUrl,
        //        new FirebaseOptions
        //        {
        //            AuthTokenAsyncFactory = () => Task.FromResult(authToken)
        //        });
        //}

        //public async Task<UserActivity> GetUserActivityAsync(string userId)
        //{
        //    var userActivity = await _firebaseClient
        //        .Child("UserActivities")
        //        .Child(userId)
        //        .OnceSingleAsync<UserActivity>();
        //    return userActivity;
        //}

        //public async Task SaveUserActivityAsync(string userId, UserActivity activity)
        //{
        //    await _firebaseClient
        //        .Child("UserActivities")
        //        .Child(userId)
        //        .PutAsync(activity);
        //}

        private readonly FirestoreDb _firestoreDb;
        private readonly FirebaseAuthClient _firebaseAuthClient;


        private readonly FirebaseClient _firebaseClient;

        // Initialize FirebaseClient without an auth token
        public FirestoreService()
        {
            _firebaseClient = new FirebaseClient("https://travelmate-7ee8e-default-rtdb.firebaseio.com/");
        }

        public async Task<UserActivity> GetUserActivityAsync(string userId)
        {
            return null;
        }

        

        public async Task SaveUserActivityAsync(string userId, UserActivity activity)
        {
            await _firebaseClient
                .Child("UserActivities")
                .Child(userId)
                .PutAsync(activity);


        }
        public async Task SaveSelectedItemsAsync(string userId, List<string> selectedItems)
        {
            await _firebaseClient
                .Child("UserChecklists")
                .Child(userId)
                .PutAsync(selectedItems);
        }
        //public async Task<string> GetAuthTokenAsync()
        //{
        //    var user = await _firebaseAuthClient.User.GetUserAsync();
        //    return await user.GetIdTokenAsync();
        //}



    }

    public class UserActivity
    {
        public string ActivityType { get; set; }
        public DateTime ActivityDate { get; set; }

        public string TripName {  get; set; }
    }
}
