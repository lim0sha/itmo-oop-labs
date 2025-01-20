using Itmo.ObjectOrientedProgramming.Lab3.RenderableModel.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextModel.Interfaces;

public interface ITxt<out T> : IRenderable where T : ITxt<T>
{
    T AddModifier(IModifier modifier);
}