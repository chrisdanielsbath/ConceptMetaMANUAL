-- Concept
CREATE TABLE dbo.Concept (
    ConceptId int NOT NULL,
    ConceptModelId int NOT NULL,
    ConceptName nvarchar(200) NOT NULL,
    ConceptDescription nvarchar(500) NULL,
    ConceptType nvarchar(max) NOT NULL,
    DataTypeId int NULL,
    EnumerationId int NULL,
    BasedOnConceptId int NULL,
    ExampleValueAsString nvarchar(200) NULL,
    MinLength int NULL,
    MaxLength int NULL,
    MinValue decimal(18, 3) NULL,
    MaxValue decimal(18, 3) NULL,
    TotalDigits int NULL,
    DecimalPlaces int NULL,
    DatePrecision int NULL,
    DbSchemaName nvarchar(200) NULL,
    DbTableName nvarchar(200) NULL,
    IsCollectionItem bit NULL,
    ToStringExpression nvarchar(200) NULL,
    IsCreatable bit NULL,
    IsUpdatable bit NULL,
    IsDeletable bit NULL,
    SurrogateKeyFieldName nvarchar(200) NULL,
    PrimaryKeyName nvarchar(200) NULL,
    AlternateKeyName nvarchar(200) NULL,
    ReferencedConceptId int NULL,
    ReferencedConceptUniqueKeyId int NULL,
    SpecialisedConceptId int NULL,
    SpecialisedConceptSubTypeId int NULL,
    CONSTRAINT PK_Concept PRIMARY KEY CLUSTERED (ConceptId)
)

CREATE UNIQUE INDEX AK_Concept_ConceptModelId_ConceptName ON dbo.Concept (ConceptModelId, ConceptName)CREATE UNIQUE INDEX PK2_CommonConcept ON dbo.Concept (ConceptId)CREATE UNIQUE INDEX PK3_ScalarConcept ON dbo.Concept (ConceptId)CREATE UNIQUE INDEX PK4_ObjectConcept ON dbo.Concept (ConceptId)CREATE UNIQUE INDEX PK5_UniqueKeyConcept ON dbo.Concept (ConceptId)CREATE UNIQUE INDEX PK6_SubTypeConcept ON dbo.Concept (ConceptId)
GO

-- ConceptModel
CREATE TABLE dbo.ConceptModel (
    ConceptModelId int NOT NULL,
    ModelName nvarchar(200) NULL,
    DefaultStringLength int NULL,
    CONSTRAINT PK_ConceptModel PRIMARY KEY CLUSTERED (ConceptModelId)
)

CREATE UNIQUE INDEX AK_ConceptModel_ModelName ON dbo.ConceptModel (ModelName)
GO

-- ConceptPropertyFamily
CREATE TABLE dbo.ConceptPropertyFamily (
    ConceptPropertyFamilyId int NOT NULL,
    ConceptId int NOT NULL,
    PropertyFamilyName nvarchar(200) NOT NULL,
    SeqNo int NOT NULL,
    CONSTRAINT PK_ConceptPropertyFamily PRIMARY KEY CLUSTERED (ConceptPropertyFamilyId)
)

CREATE UNIQUE INDEX AK_ConceptPropertyFamily_ConceptId_PropertyFamilyName ON dbo.ConceptPropertyFamily (ConceptId, PropertyFamilyName)
GO

-- ConceptRef
CREATE TABLE dbo.ConceptRef (
    ConceptRefId int NOT NULL,
    ConceptId int NOT NULL,
    PropertyName nvarchar(200) NULL,
    PropertyDescription nvarchar(200) NULL,
    ReferencedConceptId int NOT NULL,
    ConceptRefType nvarchar(200) NOT NULL,
    ConceptPropertyFamilyId int NULL,
    IsPropagating bit NULL,
    DbColumnName nvarchar(200) NULL,
    IsIdentity bit NULL,
    IsCoreField bit NULL,
    FieldFamilyName nvarchar(200) NULL,
    IsUpdatable bit NULL,
    FieldLabel nvarchar(200) NULL,
    IsScalarFieldToSerialiseInPersistenceModel bit NULL,
    IsScalarFieldToSerialiseInDomainModel bit NULL,
    IsSeqNoField bit NULL,
    IsDiscriminatorField bit NULL,
    IsXmlAttribute bit NULL,
    IsReferenceToChildEntity bit NULL,
    ParentQualifier nvarchar(200) NULL,
    ChildQualifier nvarchar(200) NULL,
    MinChildOccurrences int NULL,
    MaxChildOccurrences int NULL,
    ChildVerbPhrase nvarchar(200) NULL,
    ParentVerbPhrase nvarchar(200) NULL,
    ChildPropertySeq int NULL,
    ChildCollectionName nvarchar(200) NULL,
    ChildItemName nvarchar(200) NULL,
    ChildPropertyDescription nvarchar(200) NULL,
    SelectorType nvarchar(200) NULL,
    RelationshipType nvarchar(200) NULL,
    OutputExplicitXmlCollection bit NULL,
    IsSerialisedUsingScalarFieldInDomainModel bit NULL,
    ScalarFieldNameInDomainModel nvarchar(200) NULL,
    ExampleValueAsString nvarchar(200) NULL,
    RelationshipName nvarchar(200) NULL,
    DbForeignKeyName nvarchar(200) NULL,
    ParentIndexName nvarchar(200) NULL,
    ForeignKeySurrogateKeyFieldName nvarchar(200) NULL,
    ChildPropertyName nvarchar(200) NULL,
    IsNullable bit NULL,
    PropertySeq int NULL,
    CONSTRAINT PK_ConceptRef PRIMARY KEY CLUSTERED (ConceptRefId)
)

CREATE UNIQUE INDEX AK_ConceptRef_ConceptId_PropertyName ON dbo.ConceptRef (ConceptId, PropertyName)
GO

-- ConceptSubType
CREATE TABLE dbo.ConceptSubType (
    ConceptSubTypeId int NOT NULL,
    ConceptId int NOT NULL,
    SubTypeName nvarchar(200) NOT NULL,
    CONSTRAINT PK_ConceptSubType PRIMARY KEY CLUSTERED (ConceptSubTypeId)
)

CREATE UNIQUE INDEX AK_ConceptSubType_ConceptId_SubTypeName ON dbo.ConceptSubType (ConceptId, SubTypeName)
GO

-- ConceptSubTypePropertyFamilyRef
CREATE TABLE dbo.ConceptSubTypePropertyFamilyRef (
    ConceptSubTypePropertyFamilyRefId int NOT NULL,
    ConceptSubTypeId int NOT NULL,
    ConceptPropertyFamilyId int NOT NULL,
    SeqNo int NOT NULL,
    CONSTRAINT PK_ConceptSubTypePropertyFamilyRef PRIMARY KEY CLUSTERED (ConceptSubTypePropertyFamilyRefId)
)

CREATE UNIQUE INDEX AK_ConceptSubTypePropertyFamilyRef_ConceptSubTypeId_ConceptPropertyFamilyId ON dbo.ConceptSubTypePropertyFamilyRef (ConceptSubTypeId, ConceptPropertyFamilyId)
GO

-- ConceptUniqueKey
CREATE TABLE dbo.ConceptUniqueKey (
    ConceptUniqueKeyId int NOT NULL,
    ConceptId int NOT NULL,
    UniqueKeyName nvarchar(200) NOT NULL,
    CONSTRAINT PK_ConceptUniqueKey PRIMARY KEY CLUSTERED (ConceptUniqueKeyId)
)

CREATE UNIQUE INDEX AK_ConceptUniqueKey_ConceptId_UniqueKeyName ON dbo.ConceptUniqueKey (ConceptId, UniqueKeyName)
GO

-- ConceptUniqueKeyPropertyFamilyRef
CREATE TABLE dbo.ConceptUniqueKeyPropertyFamilyRef (
    ConceptUniqueKeyPropertyFamilyRefId int NOT NULL,
    ConceptUniqueKeyId int NOT NULL,
    ConceptPropertyFamilyId int NOT NULL,
    SeqNo int NOT NULL,
    CONSTRAINT PK_ConceptUniqueKeyPropertyFamilyRef PRIMARY KEY CLUSTERED (ConceptUniqueKeyPropertyFamilyRefId)
)

CREATE UNIQUE INDEX AK_ConceptUniqueKeyPropertyFamilyRef_ConceptUniqueKeyId_ConceptPropertyFamilyId ON dbo.ConceptUniqueKeyPropertyFamilyRef (ConceptUniqueKeyId, ConceptPropertyFamilyId)
GO

-- DataType
CREATE TABLE dbo.DataType (
    DataTypeId int NOT NULL,
    ConceptModelId int NOT NULL,
    DataTypeName nvarchar(200) NOT NULL,
    SqlServerDataType nvarchar(200) NULL,
    OracleDataType nvarchar(200) NULL,
    MySqlDataType nvarchar(200) NULL,
    MongoDbDataType nvarchar(200) NULL,
    DotNetDataType nvarchar(200) NULL,
    JavaDataType nvarchar(200) NULL,
    XmlDataType nvarchar(200) NULL,
    ExampleValueAsString nvarchar(200) NULL,
    JsonDataType nvarchar(200) NULL,
    JsonFormat nvarchar(200) NULL,
    OpenApiDataType nvarchar(200) NULL,
    OpenApiFormat nvarchar(200) NULL,
    ErsDataType nvarchar(200) NULL,
    BasicDataType nvarchar(200) NULL,
    MinLength int NULL,
    MaxLength int NULL,
    MinValue decimal(18, 3) NULL,
    MaxValue decimal(18, 3) NULL,
    TotalDigits int NULL,
    DecimalPlaces int NULL,
    DatePrecision int NULL,
    HasLength bit NULL,
    HasTotalDigits bit NULL,
    HasDecimalPlaces bit NULL,
    HasIdentity bit NULL,
    HasDatePrecision bit NULL,
    CONSTRAINT PK_DataType PRIMARY KEY CLUSTERED (DataTypeId)
)

CREATE UNIQUE INDEX AK_DataType_ConceptModelId_DataTypeName ON dbo.DataType (ConceptModelId, DataTypeName)
GO

-- Enumeration
CREATE TABLE dbo.Enumeration (
    EnumerationId int NOT NULL,
    ConceptModelId int NOT NULL,
    EnumerationName nvarchar(200) NULL,
    EnumerationDescription nvarchar(500) NULL,
    DataTypeId int NOT NULL,
    CONSTRAINT PK_Enumeration PRIMARY KEY CLUSTERED (EnumerationId)
)

CREATE UNIQUE INDEX AK_Enumeration_ConceptModelId_EnumerationName ON dbo.Enumeration (ConceptModelId, EnumerationName)
GO

-- EnumerationMember
CREATE TABLE dbo.EnumerationMember (
    EnumerationMemberId int NOT NULL,
    EnumerationId int NOT NULL,
    EnumeratedValue nvarchar(200) NOT NULL,
    EnumeratedValueDescription nvarchar(500) NULL,
    CONSTRAINT PK_EnumerationMember PRIMARY KEY CLUSTERED (EnumerationMemberId)
)

CREATE UNIQUE INDEX AK_EnumerationMember_EnumerationId_EnumeratedValue ON dbo.EnumerationMember (EnumerationId, EnumeratedValue)
GO

-- Include
CREATE TABLE dbo.Include (
    IncludeId int NOT NULL,
    ConceptId int NOT NULL,
    ItemValue nvarchar(200) NULL,
    SeqNo int NOT NULL,
    CONSTRAINT PK_Include PRIMARY KEY CLUSTERED (IncludeId)
)

CREATE UNIQUE INDEX AK_Include_ConceptId_ItemValue ON dbo.Include (ConceptId, ItemValue)
GO

-- Qualifier
CREATE TABLE dbo.Qualifier (
    QualifierId int NOT NULL,
    ConceptId int NOT NULL,
    ItemValue nvarchar(200) NOT NULL,
    SeqNo int NOT NULL,
    CONSTRAINT PK_Qualifier PRIMARY KEY CLUSTERED (QualifierId)
)

CREATE UNIQUE INDEX AK_Qualifier_ConceptId_ItemValue ON dbo.Qualifier (ConceptId, ItemValue)
GO

ALTER TABLE dbo.Concept ADD CONSTRAINT FK_Concept_BasedOnConceptId FOREIGN KEY (BasedOnConceptId) REFERENCES dbo.Concept (ConceptId)
ALTER TABLE dbo.Concept ADD CONSTRAINT FK_Concept_DataTypeId FOREIGN KEY (DataTypeId) REFERENCES dbo.DataType (DataTypeId)
ALTER TABLE dbo.Concept ADD CONSTRAINT FK_Concept_EnumerationId FOREIGN KEY (EnumerationId) REFERENCES dbo.Enumeration (EnumerationId)
ALTER TABLE dbo.Include ADD CONSTRAINT FK_Include_ConceptId FOREIGN KEY (ConceptId) REFERENCES dbo.Concept (ConceptId)
ALTER TABLE dbo.ConceptRef ADD CONSTRAINT FK_ConceptRef_ConceptId FOREIGN KEY (ConceptId) REFERENCES dbo.Concept (ConceptId)
ALTER TABLE dbo.ConceptPropertyFamily ADD CONSTRAINT FK_ConceptPropertyFamily_ConceptId FOREIGN KEY (ConceptId) REFERENCES dbo.Concept (ConceptId)
ALTER TABLE dbo.Qualifier ADD CONSTRAINT FK_Qualifier_ConceptId FOREIGN KEY (ConceptId) REFERENCES dbo.Concept (ConceptId)
ALTER TABLE dbo.Concept ADD CONSTRAINT FK_Concept_ReferencedConceptId FOREIGN KEY (ReferencedConceptId) REFERENCES dbo.Concept (ConceptId)
ALTER TABLE dbo.Concept ADD CONSTRAINT FK_Concept_ReferencedConceptUniqueKeyId FOREIGN KEY (ReferencedConceptUniqueKeyId) REFERENCES dbo.ConceptUniqueKey (ConceptUniqueKeyId)
ALTER TABLE dbo.Concept ADD CONSTRAINT FK_Concept_SpecialisedConceptId FOREIGN KEY (SpecialisedConceptId) REFERENCES dbo.Concept (ConceptId)
ALTER TABLE dbo.Concept ADD CONSTRAINT FK_Concept_SpecialisedConceptSubTypeId FOREIGN KEY (SpecialisedConceptSubTypeId) REFERENCES dbo.ConceptSubType (ConceptSubTypeId)
ALTER TABLE dbo.ConceptSubType ADD CONSTRAINT FK_ConceptSubType_ConceptId FOREIGN KEY (ConceptId) REFERENCES dbo.Concept (ConceptId)
ALTER TABLE dbo.ConceptUniqueKey ADD CONSTRAINT FK_ConceptUniqueKey_ConceptId FOREIGN KEY (ConceptId) REFERENCES dbo.Concept (ConceptId)
ALTER TABLE dbo.Concept ADD CONSTRAINT FK_Concept_ConceptModelId FOREIGN KEY (ConceptModelId) REFERENCES dbo.ConceptModel (ConceptModelId)
ALTER TABLE dbo.DataType ADD CONSTRAINT FK_DataType_ConceptModelId FOREIGN KEY (ConceptModelId) REFERENCES dbo.ConceptModel (ConceptModelId)
ALTER TABLE dbo.Enumeration ADD CONSTRAINT FK_Enumeration_ConceptModelId FOREIGN KEY (ConceptModelId) REFERENCES dbo.ConceptModel (ConceptModelId)
ALTER TABLE dbo.ConceptRef ADD CONSTRAINT FK_ConceptRef_ConceptPropertyFamilyId FOREIGN KEY (ConceptPropertyFamilyId) REFERENCES dbo.ConceptPropertyFamily (ConceptPropertyFamilyId)
ALTER TABLE dbo.ConceptRef ADD CONSTRAINT FK_ConceptRef_ReferencedConceptId FOREIGN KEY (ReferencedConceptId) REFERENCES dbo.Concept (ConceptId)
ALTER TABLE dbo.ConceptSubTypePropertyFamilyRef ADD CONSTRAINT FK_ConceptSubTypePropertyFamilyRef_ConceptSubTypeId FOREIGN KEY (ConceptSubTypeId) REFERENCES dbo.ConceptSubType (ConceptSubTypeId)
ALTER TABLE dbo.ConceptSubTypePropertyFamilyRef ADD CONSTRAINT FK_ConceptSubTypePropertyFamilyRef_ConceptPropertyFamilyId FOREIGN KEY (ConceptPropertyFamilyId) REFERENCES dbo.ConceptPropertyFamily (ConceptPropertyFamilyId)
ALTER TABLE dbo.ConceptUniqueKeyPropertyFamilyRef ADD CONSTRAINT FK_ConceptUniqueKeyPropertyFamilyRef_ConceptUniqueKeyId FOREIGN KEY (ConceptUniqueKeyId) REFERENCES dbo.ConceptUniqueKey (ConceptUniqueKeyId)
ALTER TABLE dbo.ConceptUniqueKeyPropertyFamilyRef ADD CONSTRAINT FK_ConceptUniqueKeyPropertyFamilyRef_ConceptPropertyFamilyId FOREIGN KEY (ConceptPropertyFamilyId) REFERENCES dbo.ConceptPropertyFamily (ConceptPropertyFamilyId)
ALTER TABLE dbo.Enumeration ADD CONSTRAINT FK_Enumeration_DataTypeId FOREIGN KEY (DataTypeId) REFERENCES dbo.DataType (DataTypeId)
ALTER TABLE dbo.EnumerationMember ADD CONSTRAINT FK_EnumerationMember_EnumerationId FOREIGN KEY (EnumerationId) REFERENCES dbo.Enumeration (EnumerationId)

GO
