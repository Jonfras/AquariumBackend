namespace Backend.Controllers;

[Route("[controller]")]
public class GameController(GameService gameService) : ControllerBase {

    [HttpPost("coins")]
    public ResponseEntity<UserCoinsDto> SaveCoins([FromBody] UserCoinsDto dto) {
        return gameService.SaveCoins(dto);
    }

    [HttpGet("coins")]
    public ResponseEntity<UserCoinsDto> SaveCoins(int userId) {
        return gameService.GetGameState(userId);
    }

    [HttpPost("fish")]
    public ResponseEntity<List<FishDto>> SaveFish([FromBody] List<FishDto> fishDtos) {
        return gameService.SaveFish(fishDtos);
    }

    [HttpGet("fish/{userId}")]
    public ResponseEntity<List<FishDto>> GetFish(int userId) {
        return gameService.GetFish(userId);
    }

    [HttpPost("decorations")]
    public ResponseEntity<List<DecorationDto>> SaveDecorations([FromBody] List<DecorationDto> decorationDtos) {
        return gameService.SaveDecorations(decorationDtos);
    }

    [HttpGet("decorations/{userId}")]
    public ResponseEntity<List<DecorationDto>> GetDecorations(int userId) {
        return gameService.GetDecorations(userId);
    }
}
