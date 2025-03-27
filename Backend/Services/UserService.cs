
using Microsoft.EntityFrameworkCore.Storage;
using System.Security.Cryptography.X509Certificates;

namespace Backend.Services;
public class UserService(AquariumContext db) {
    internal ResponseEntity<UserDto> Login(UserDto userDto) {
        try {
            if (string.IsNullOrEmpty(userDto.Username) || string.IsNullOrEmpty(userDto.PasswordHash)) {
                throw new Exception("Username and password are required");
            }

            var user = db.Users.FirstOrDefault(x => x.Username == userDto.Username);

            if (user == null) {
                throw new Exception("User not found");
            }

            if (user.PasswordHash != userDto.PasswordHash) {
                throw new Exception("Invalid password");
            }

            user.LastLogin = DateTime.Now;
            db.SaveChanges();

            return new ResponseEntity<UserDto>() {
                Data = new UserDto().CopyFrom(user)
            };
        }
        catch (Exception e) {
            return new ResponseEntity<UserDto>() {
                Data = null,
                ErrorMessage = e.Message ?? "Something went wrong"
            };
        }
    }

    internal ResponseEntity<UserDto> Register(UserDto userDto) {
        db.Users.Select(x => @$"{x.Id} {x.Username} {x.PasswordHash}").ToList()
            .ForEach(Console.WriteLine);

        try {
            if (userDto.Id != null) {
                throw new Exception("Id must be null when registering");
            }

            if (db.Users.Any(x => x.Username == userDto.Username)) {
                throw new Exception("Username already exists");
            }

            var user = new User().CopyFrom(userDto);
            user.CreatedAt = DateTime.Now;
            var userEntity = db.Users.Add(user);
            db.SaveChanges();
            return new ResponseEntity<UserDto>() { Data = new UserDto().CopyFrom(userEntity.Entity) };
        }
        catch (Exception e) {
            return new ResponseEntity<UserDto>() {
                Data = null,
                ErrorMessage = e.Message ?? "Something went wrong"
            };
        }
    }
    public bool UserIdExists(int id) {
        return db.Users.Any(x => x.Id == id);
    }
}
