// Decompiled with JetBrains decompiler
// Type: Amplitude.Mercury.Interop.EditorOrderEvolveCampToCity
// Assembly: Amplitude.Mercury.Firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C6020605-CF00-449D-A856-BC7A2B6C1CDA
// Assembly location: C:\HUMANKIND\Humankind_Data\Managed\Amplitude.Mercury.Firstpass.dll

using Amplitude.IO;
using Amplitude.Serialization;

namespace Amplitude.Mercury.Interop
{
  public class EditorOrderEvolveCampToCity : EditorOrder
  {
    public int CampTileIndex;

    public override OrderIdentifier OrderIdentifier => OrderIdentifier.EditorOrderEvolveCampToCity;

    public override void Pack(BinaryMemoryStream writer)
    {
      base.Pack(writer);
      writer.Write(this.CampTileIndex);
    }

    public override void Unpack(BinaryMemoryStream reader)
    {
      base.Unpack(reader);
      this.CampTileIndex = reader.ReadInt32();
    }

    public override void Serialize(Serializer serializer) => this.CampTileIndex = serializer.SerializeElement("CampTileIndex", this.CampTileIndex);

    internal override bool TryResolveEmpireIndexes(EditorOrdersEmpireIndexResolver resolver) => true;
  }
}
