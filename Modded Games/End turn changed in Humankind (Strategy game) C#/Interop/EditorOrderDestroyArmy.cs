// Decompiled with JetBrains decompiler
// Type: Amplitude.Mercury.Interop.EditorOrderDestroyArmy
// Assembly: Amplitude.Mercury.Firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C6020605-CF00-449D-A856-BC7A2B6C1CDA
// Assembly location: C:\HUMANKIND\Humankind_Data\Managed\Amplitude.Mercury.Firstpass.dll

using Amplitude.IO;
using Amplitude.Serialization;

namespace Amplitude.Mercury.Interop
{
  public class EditorOrderDestroyArmy : EditorOrder
  {
    public int ArmyTileIndex;

    public override OrderIdentifier OrderIdentifier => OrderIdentifier.EditorOrderDestroyArmy;

    public override void Pack(BinaryMemoryStream writer)
    {
      base.Pack(writer);
      writer.Write(this.ArmyTileIndex);
    }

    public override void Unpack(BinaryMemoryStream reader)
    {
      base.Unpack(reader);
      this.ArmyTileIndex = reader.ReadInt32();
    }

    public override void Serialize(Serializer serializer) => this.ArmyTileIndex = serializer.SerializeElement("ArmyTileIndex", this.ArmyTileIndex);

    internal override bool TryResolveEmpireIndexes(EditorOrdersEmpireIndexResolver resolver) => true;
  }
}
