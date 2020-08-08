using System.Collections;

public class CatTransitionData 
{
    public Mood DestionationMood;
    public Reaction Reaction;

    public CatTransitionData(Mood destinationMood, Reaction reaction)
    {
        DestionationMood = destinationMood;
        Reaction = reaction;
    }
}
