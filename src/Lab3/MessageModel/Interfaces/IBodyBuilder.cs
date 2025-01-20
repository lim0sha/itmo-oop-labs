using Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.RenderableModel.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Interfaces;

public interface IBodyBuilder
{
    BuilderBase WithBody(IRenderable body);
}