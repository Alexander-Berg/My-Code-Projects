// Decompiled with JetBrains decompiler
// Type: Amplitude.Mercury.Interop.EditorOrderPathCuriosityRemovePath
// Assembly: Amplitude.Mercury.Firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C6020605-CF00-449D-A856-BC7A2B6C1CDA
// Assembly location: C:\HUMANKIND\Humankind_Data\Managed\Amplitude.Mercury.Firstpass.dll

using Amplitude.IO;
using Amplitude.Serialization;

namespace Amplitude.Mercury.Interop
{
  public class EditorOrderPathCuriosityRemovePath : EditorOrder
  {
    public int PathIndex;

    public override OrderIdentifier OrderIdentifier => OrderIdentifier.EditorOrderPathCuriosityRemovePath;

    public override void Pack(BinaryMemoryStream writer)
    {
      base.Pack(writer);
      writer.Write(this.PathIndex);
    }

    public override void Unpack(BinaryMemoryStream reader)
    {
      base.Unpack(reader);
      this.PathIndex = reader.ReadInt32();
    }

    public override void Serialize(Serializer serializer) => this.PathIndex = serializer.SerializeElement("PathIndex", this.PathIndex);

    internal override bool TryResolveEmpireIndexes(EditorOrdersEmpireIndexResolver resolver) => true;
  }
}
