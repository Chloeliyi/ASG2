public class Leaderboard {
    public string username;
    public int checkpoints;
    public float time;
    public int quizpoints;
    public Leaderboard() {
    }

    public Leaderboard(string username, int checkpoints, float time, int quizpoints) {
        this.username = username;
        this.checkpoints = checkpoints;
        this.time = time;
        this.quizpoints = quizpoints;
    }
}
