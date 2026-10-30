using System.Collections;
using System.Collections.Generic;
using System.Windows.Markup;

namespace PCL;

[ContentProperty("Events")]
public class CustomEventCollection : IEnumerable<CustomEvent>
{
    private List<CustomEvent> _Events;

    public List<CustomEvent> Events => _Events;

    public CustomEventCollection()
    {
        _Events = new List<CustomEvent>();
    }

    public IEnumerator<CustomEvent> GetEnumerator()
    {
        return ((IEnumerable<CustomEvent>)Events).GetEnumerator();
    }

    IEnumerator<CustomEvent> IEnumerable<CustomEvent>.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private IEnumerator IEnumerable_GetEnumerator()
    {
        return ((IEnumerable)Events).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.IEnumerable_GetEnumerator();
    }
}
