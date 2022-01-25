﻿// Decompiled with JetBrains decompiler
// Type: Amplitude.Mercury.Interop.EditorOrderDestroySettlement
// Assembly: Amplitude.Mercury.Firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C6020605-CF00-449D-A856-BC7A2B6C1CDA
// Assembly location: C:\HUMANKIND\Humankind_Data\Managed\Amplitude.Mercury.Firstpass.dll

using Amplitude.IO;
using Amplitude.Serialization;

namespace Amplitude.Mercury.Interop
{
  public class EditorOrderDestroySettlement : EditorOrder
  {
    public int SettlementTileIndex;

    public override OrderIdentifier OrderIdentifier => OrderIdentifier.EditorOrderDestroySettlement;

    public override void Pack(BinaryMemoryStream writer)
    {
      base.Pack(writer);
      writer.Write(this.SettlementTileIndex);
    }

    public override void Unpack(BinaryMemoryStream reader)
    {
      base.Unpack(reader);
      this.SettlementTileIndex = reader.ReadInt32();
    }

    public override void Serialize(Serializer serializer) => this.SettlementTileIndex = serializer.SerializeElement("SettlementTileIndex", this.SettlementTileIndex);

    internal override bool TryResolveEmpireIndexes(EditorOrdersEmpireIndexResolver resolver) => true;
  }
}
