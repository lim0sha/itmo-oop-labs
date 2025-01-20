using Itmo.ObjectOrientedProgramming.Lab3.RenderableModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.RenderableModel.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Interfaces;

public interface IApplier
{
    Modifier ApplyModifier(IRenderable renderable, IModifier modifier);
}