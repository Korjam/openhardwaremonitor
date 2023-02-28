using OxyPlot;
using OxyPlot.Annotations;
using System;

namespace OpenHardwareMonitor.Modern.ViewModel;

public class DelegateAnnotation : Annotation
{
    private Action<IRenderContext> _renderingAction;

    /// <summary>
    /// Initializes a new instance of the <see cref="DelegateAnnotation"/> class.
    /// </summary>
    /// <param name="rendering">The rendering delegate.</param>
    public DelegateAnnotation(Action<IRenderContext> rendering)
    {
        _renderingAction = rendering;
    }

    /// <summary>
    /// Renders the annotation on the specified context.
    /// </summary>
    /// <param name="rc">The render context.</param>
    public override void Render(IRenderContext rc)
    {
        base.Render(rc);
        _renderingAction(rc);
    }

    /// <inheritdoc/>
    public override OxyRect GetClippingRect() => OxyRect.Everything;
}