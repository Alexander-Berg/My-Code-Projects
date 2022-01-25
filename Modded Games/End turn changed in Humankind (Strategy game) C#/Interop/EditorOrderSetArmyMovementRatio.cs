// Decompiled with JetBrains decompiler
// Type: Amplitude.Mercury.Interop.EditorOrderSetArmyMovementRatio
// Assembly: Amplitude.Mercury.Firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C6020605-CF00-449D-A856-BC7A2B6C1CDA
// Assembly location: C:\HUMANKIND\Humankind_Data\Managed\Amplitude.Mercury.Firstpass.dll

using Amplitude.IO;
using Amplitude.Serialization;

namespace Amplitude.Mercury.Interop
{
  public class EditorOrderSetArmyMovementRatio : EditorOrder
  {
    public int ArmyTileIndex;
    public float MovementRatio;

    public override OrderIdentifier OrderIdentifier => OrderIdentifier.EditorOrderSetArmyMovementRatio;

    public override void Pack(BinaryMemoryStream writer)
    {
      base.Pack(writer);
      writer.Write(this.ArmyTileIndex);
      writer.Write(this.MovementRatio);
    }

    public override void Unpack(BinaryMemoryStream reader)
    {
      base.Unpack(reader);
      this.ArmyTileIndex = reader.ReadInt32();
      this.MovementRatio = reader.ReadSingle();
    }

    public override void Serialize(Serializer serializer)
    {
      this.ArmyTileIndex = serializer.SerializeElement("ArmyTileIndex", this.ArmyTileIndex);
      this.MovementRatio = serializer.SerializeElement("MovementRatio", this.MovementRatio);
    }

    internal override bool TryResolveEmpireIndexes(EditorOrdersEmpireIndexResolver resolver) => true;
  }
}
