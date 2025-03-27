namespace Backend.Controllers;

[Route("[controller]")]
public class GameController(GameService gameService) : ControllerBase {

    [HttpPost("coins")]
    public ResponseEntity<UserCoinsDto> SaveCoins([FromBody] UserCoinsDto dto) {
        return gameService.SaveCoins(dto);
    }

    [HttpPost("fish")]
    public ResponseEntity<List<FishDto>> SaveFish([FromBody] List<FishDto> fishDtos) {
        return gameService.SaveFish(fishDtos);
    }

    [HttpGet("fish/{userId}")]
    public ResponseEntity<List<FishDto>> GetFish(int userId) {
        return gameService.GetFish(userId);
    }
}
