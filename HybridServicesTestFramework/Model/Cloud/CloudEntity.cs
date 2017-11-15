using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HybridServicesTestFramework.Model.Cloud
{
	[DataContract]
	public class CloudEntityListContainer<T>
	{
		[DataMember(Name = "data", IsRequired = true, EmitDefaultValue = false)]
		public IList<T> Data;
	}

	[DataContract]
	public class CloudAppEntityContainer
	{
		[DataMember(Name = "data", IsRequired = true, EmitDefaultValue = false)]
		public CloudAppEntity Data;
	}

	[DataContract]
	public class CloudAppEntity
	{
		[DataMember(Name = "id", IsRequired = false, EmitDefaultValue = false)]
		public string id;

		[DataMember(Name = "title", IsRequired = true)]
		public string Title;

		[DataMember(Name = "source", IsRequired = false)]
		public CloudSourceInfoEntity Source;

		[DataMember(Name = "groupId", IsRequired = false)]
		public string GroupId { get; set; }

		[DataMember(Name = "owner", IsRequired = false)]
		public string Owner { get; set; }

		[DataMember(Name = "published", IsRequired = false)]
		public bool Published { get; set; }

		[DataMember(Name = "region", IsRequired = false)]
		public string Region { get; set; }

		[DataMember(Name = "size", IsRequired = false)]
		public long Size { get; set; }

		[DataMember(Name = "created", IsRequired = false)]
		public DateTime? Created { get; set; }

		[DataMember(Name = "lastUpdated", IsRequired = false)]
		public DateTime? LastUpdated { get; set; }

		[DataMember(Name = "currentVersion", IsRequired = false)]
		public string CurrentVersion { get; set; }

		[DataMember(Name = "stream", IsRequired = false)]
		public object Stream { get; set; }

	}

	[DataContract]
	public class CloudSourceInfoEntity
	{
		[DataMember(Name = "id", IsRequired = false)]
		public Guid? Id;

		[DataMember(Name = "serverID", IsRequired = false)]
		public Guid? ServerId;
	}

	[DataContract]
	public class CloudGroupEntity
	{
		[DataMember(Name = "id", IsRequired = false, EmitDefaultValue = false)]
		public string Id;

		[DataMember(Name = "name", IsRequired = true)]
		public string Name;

		[DataMember(Name = "owner", IsRequired = false)]
		public string Owner;

		[DataMember(Name = "region", IsRequired = false)]
		public string Region;

		[DataMember(Name = "created", IsRequired = false)]
		public string Created;
	}

	[DataContract]
	public class CloudStreamEntity
	{
		[DataMember(Name = "id", IsRequired = false, EmitDefaultValue = false)]
		public string Id;

		[DataMember(Name = "name", IsRequired = true)]
		public string Name;

		[DataMember(Name = "owner", IsRequired = false)]
		public string Owner;

		[DataMember(Name = "type", IsRequired = false)]
		public string Type;

		[DataMember(Name = "created", IsRequired = false)]
		public string Created;
	}
}
