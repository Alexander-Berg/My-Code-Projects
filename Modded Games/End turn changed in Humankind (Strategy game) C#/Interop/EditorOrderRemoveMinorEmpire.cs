// Decompiled with JetBrains decompiler
// Type: Amplitude.Mercury.Interop.EditorOrderRemoveMinorEmpire
// Assembly: Amplitude.Mercury.Firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C6020605-CF00-449D-A856-BC7A2B6C1CDA
// Assembly location: C:\HUMANKIND\Humankind_Data\Managed\Amplitude.Mercury.Firstpass.dll

using Amplitude.IO;
using Amplitude.Serialization;

namespace Amplitude.Mercury.Interop
{
  public class EditorOrderRemoveMinorEmpire : EditorOrder
  {
    public int MinorEmpireIndex;

    public override OrderIdentifier OrderIdentifier => OrderIdentifier.EditorOrderRemoveMinorEmpire;

    public override void Pack(BinaryMemoryStream writer)
    {
      base.Pack(writer);
      writer.Write(this.MinorEmpireIndex);
    }

    public override void Unpack(BinaryMemoryStream reader)
    {
      base.Unpack(reader);
      this.MinorEmpireIndex = reader.ReadInt32();
    }

    public override void Serialize(Serializer serializer) => this.MinorEmpireIndex = serializer.SerializeElement("MinorEmpireIndex", this.MinorEmpireIndex);

    internal override bool TryResolveEmpireIndexes(EditorOrdersEmpireIndexResolver resolver) => resolver.TryResolveEmpireIndex(ref this.MinorEmpireIndex);
  }
}
