public class Leader {
    public string username;
    public float checkpoints;
    public float time;
    public int quizpoints;
    public Leader() {
    }

    public Leader(string username, float checkpoints, float time, int quizpoints) {
        this.username = username;
        this.checkpoints = checkpoints;
        this.time = time;
        this.quizpoints = quizpoints;
    }
}
