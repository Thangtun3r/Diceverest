public enum InteractionState { Hovered, Selected, Deselected }

public interface IDiceSelectable
{
    void HandleSelection(InteractionState state);
}