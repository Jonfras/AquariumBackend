using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Backend.Services {
    public class GameService(AquariumContext db, UserService userService) {
        internal ResponseEntity<UserCoinsDto> SaveCoins(UserCoinsDto dto) {
            var userCoins = new GameDatum().CopyFrom(dto);

            if (userCoins == null) {
                return new ResponseEntity<UserCoinsDto>() {
                    ErrorMessage = "Something went wrong when converting from the dto",
                    Data = null
                }
                ;
            }

            var userExists = userService.UserIdExists(dto.UserId);
            if (!userExists) {
                return new ResponseEntity<UserCoinsDto>() {
                    ErrorMessage = "User doesnt exist with this id",
                    Data = null
                };
            }

            var gameState = GetGameSaveState(dto.UserId);
            if (gameState != null) {
                gameState.Coins = userCoins.Coins;
                gameState.LastSaved = DateTime.Now;
            }
            else {
                db.GameData.Add(userCoins);
            }

            db.SaveChanges();
            return new ResponseEntity<UserCoinsDto>() {
                Data = new UserCoinsDto().CopyFrom(userCoins)
            };

        }

        internal GameDatum? GetGameSaveState(int userId) {
            return db.GameData.FirstOrDefault(x => x.UserId == userId);
        }

        internal ResponseEntity<List<FishDto>> SaveFish(List<FishDto> fishDtos) {
            var fishEntities = new List<Fish>();
            try {
                fishEntities = fishDtos.Select(x => new Fish().CopyFrom(x)).ToList();
            }
            catch (Exception e) {
                return new ResponseEntity<List<FishDto>>() {
                    Data = null,
                    ErrorMessage = "Something went wrong when mapping fishDtos"
                };
            }

            if (fishEntities == null || fishEntities.Count <= 0) {
                return new ResponseEntity<List<FishDto>>() {
                    Data = null,
                    ErrorMessage = "fish list is empty"
                };
            }
            var userId = fishEntities[0].UserId;

            var userExists = userService.UserIdExists(userId);

            if (!userExists) {
                return new ResponseEntity<List<FishDto>>() {
                    Data = null,
                    ErrorMessage = "User doesnt exist"
                };
            }

            db.Fish.RemoveRange(db.Fish.Where(x => x.UserId == userId).ToList());

            db.Fish.AddRange(fishEntities!);
            db.SaveChanges();


            return new ResponseEntity<List<FishDto>>() { Data = fishDtos };
        }

        internal ResponseEntity<List<FishDto>> GetFish(int userId) {
            var userExists = userService.UserIdExists(userId);

            if (!userExists) {
                return new ResponseEntity<List<FishDto>>() {
                    Data = null,
                    ErrorMessage = "User doesnt exist"
                };
            }

            var fishDtos = db.Fish.Where(x => x.UserId == userId).Select(x =>
            new FishDto().CopyFrom(x)).ToList();

            if (fishDtos == null || fishDtos.Count <= 0) {
                return new ResponseEntity<List<FishDto>>() {
                    Data = null,
                    ErrorMessage = "No fishes in the db"
                };
            }

            return new ResponseEntity<List<FishDto>>() {
                Data = fishDtos,
                ErrorMessage = ""
            }; 
        }
    }

}
