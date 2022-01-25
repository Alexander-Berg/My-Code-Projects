// Decompiled with JetBrains decompiler
// Type: Amplitude.Mercury.Interop.EditorOrderForceVassalToLiege
// Assembly: Amplitude.Mercury.Firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C6020605-CF00-449D-A856-BC7A2B6C1CDA
// Assembly location: C:\HUMANKIND\Humankind_Data\Managed\Amplitude.Mercury.Firstpass.dll

using Amplitude.IO;
using Amplitude.Serialization;

namespace Amplitude.Mercury.Interop
{
  public class EditorOrderForceVassalToLiege : EditorOrder
  {
    public int LiegeEmpireIndex = -1;
    public int VassalEmpireIndex = -1;

    public override OrderIdentifier OrderIdentifier => OrderIdentifier.EditorOrderForceVassalToLiege;

    public override void Pack(BinaryMemoryStream writer)
    {
      base.Pack(writer);
      writer.Write(this.LiegeEmpireIndex);
      writer.Write(this.VassalEmpireIndex);
    }

    public override void Unpack(BinaryMemoryStream reader)
    {
      base.Unpack(reader);
      this.LiegeEmpireIndex = reader.ReadInt32();
      this.VassalEmpireIndex = reader.ReadInt32();
    }

    public override void Serialize(Serializer serializer)
    {
      this.LiegeEmpireIndex = serializer.SerializeElement("LiegeEmpireIndex", this.LiegeEmpireIndex);
      this.VassalEmpireIndex = serializer.SerializeElement("VassalEmpireIndex", this.VassalEmpireIndex);
    }

    internal override bool TryResolveEmpireIndexes(EditorOrdersEmpireIndexResolver resolver) => resolver.TryResolveEmpireIndex(ref this.LiegeEmpireIndex) && resolver.TryResolveEmpireIndex(ref this.VassalEmpireIndex);
  }
}
