
class ObjectSize{

    public int Size(){
        var sizeMod = 0;
        Random rnd = new Random();
        sizeMod = rnd.Next(4,15);
        return sizeMod;
    }
}