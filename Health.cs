class Health{

    private int Healthvalue = 5;
    public int Healthchange(int change){
        // Updates the score with the following
        var Healthnum = Healthvalue;
        Healthnum += change;

        return Healthnum;
    }
}