/****************************
 * ConceptRef.java
 ****************************/
Package ConceptMeta.entity;

import java.io.Serializable;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.OneToMany;
import org.hibernate.annotations.Type;

/**
 * A field or relationship
 */
@Entity
@Table(name = "ConceptRef", schema = "dbo")
public class ConceptRef {

    // Instance Variables region

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "ConceptRefId")
    private Integer conceptRefId;

    @Column(name = "ConceptModelId")
    private Integer conceptModelId;

    @Column(name = "ModelName")
    private String modelName;

    @Column(name = "ConceptId")
    private Integer conceptId;

    @Column(name = "ConceptName")
    private String conceptName;

    @Column(name = "PropertyName")
    private String propertyName;

    @Column(name = "PropertyDescription")
    private String propertyDescription;

    @Column(name = "ReferencedConceptId")
    private Integer referencedConceptId;

    @Column(name = "ReferencedConceptName")
    private String referencedConceptName;

    @Column(name = "ConceptRefType")
    private String conceptRefType;

    @Column(name = "ConceptPropertyFamilyId")
    private Integer conceptPropertyFamilyId;

    @Column(name = "PropertyFamilyName")
    private String propertyFamilyName;

    @Column(name = "IsPropagating")
    private Boolean isPropagating;

    @Column(name = "DbColumnName")
    private String dbColumnName;

    @Column(name = "IsIdentity")
    private Boolean isIdentity;

    @Column(name = "IsCoreField")
    private Boolean isCoreField;

    @Column(name = "FieldFamilyName")
    private String fieldFamilyName;

    @Column(name = "IsUpdatable")
    private Boolean isUpdatable;

    @Column(name = "FieldLabel")
    private String fieldLabel;

    @Column(name = "IsScalarFieldToSerialiseInPersistenceModel")
    private Boolean isScalarFieldToSerialiseInPersistenceModel;

    @Column(name = "IsScalarFieldToSerialiseInDomainModel")
    private Boolean isScalarFieldToSerialiseInDomainModel;

    @Column(name = "IsSeqNoField")
    private Boolean isSeqNoField;

    @Column(name = "IsDiscriminatorField")
    private Boolean isDiscriminatorField;

    @Column(name = "IsXmlAttribute")
    private Boolean isXmlAttribute;

    @Column(name = "IsReferenceToChildEntity")
    private Boolean isReferenceToChildEntity;

    @Column(name = "ParentQualifier")
    private String parentQualifier;

    @Column(name = "ChildQualifier")
    private String childQualifier;

    @Column(name = "MinChildOccurrences")
    private Integer minChildOccurrences;

    @Column(name = "MaxChildOccurrences")
    private Integer maxChildOccurrences;

    @Column(name = "ChildVerbPhrase")
    private String childVerbPhrase;

    @Column(name = "ParentVerbPhrase")
    private String parentVerbPhrase;

    @Column(name = "ChildPropertySeq")
    private Integer childPropertySeq;

    @Column(name = "ChildCollectionName")
    private String childCollectionName;

    @Column(name = "ChildItemName")
    private String childItemName;

    @Column(name = "ChildPropertyDescription")
    private String childPropertyDescription;

    @Column(name = "SelectorType")
    private String selectorType;

    @Column(name = "RelationshipType")
    private String relationshipType;

    @Column(name = "OutputExplicitXmlCollection")
    private Boolean outputExplicitXmlCollection;

    @Column(name = "IsSerialisedUsingScalarFieldInDomainModel")
    private Boolean isSerialisedUsingScalarFieldInDomainModel;

    @Column(name = "ScalarFieldNameInDomainModel")
    private String scalarFieldNameInDomainModel;

    @Column(name = "ExampleValueAsString")
    private String exampleValueAsString;

    @Column(name = "RelationshipName")
    private String relationshipName;

    @Column(name = "DbForeignKeyName")
    private String dbForeignKeyName;

    @Column(name = "ParentIndexName")
    private String parentIndexName;

    @Column(name = "ForeignKeySurrogateKeyFieldName")
    private String foreignKeySurrogateKeyFieldName;

    @Column(name = "ChildPropertyName")
    private String childPropertyName;

    @Column(name = "IsNullable")
    private Boolean isNullable;

    @Column(name = "PropertySeq")
    private Integer propertySeq;

    @ManyToOne(fetch=FetchType.LAZY)
    @JoinColumn(name = "ConceptId")
    private Concept concept;

    @ManyToOne(fetch=FetchType.LAZY)
    @JoinColumn(name = "ReferencedConceptId")
    private Concept referencedConcept;

    @ManyToOne(fetch=FetchType.LAZY)
    @JoinColumn(name = "ConceptPropertyFamilyId")
    private ConceptPropertyFamily propertyFamily;

    // end of region

    // Instance Properties region

    /**
     * The ID of the ConceptRef
     */
    public Integer getConceptRefId {
        return this.conceptRefId;
    }
    public void setConceptRefId {
        conceptRefId = value;
    }

    /**
     * The ID of the Concept
     */
    public Integer getConceptId {
        return this.conceptId;
    }
    public void setConceptId {
        conceptId = value;
    }

    public String getPropertyName {
        return this.propertyName;
    }
    public void setPropertyName {
        propertyName = value;
    }

    public String getPropertyDescription {
        return this.propertyDescription;
    }
    public void setPropertyDescription {
        propertyDescription = value;
    }

    /**
     * The ID of the Referenced Concept
     */
    public Integer getReferencedConceptId {
        return this.referencedConceptId;
    }
    public void setReferencedConceptId {
        referencedConceptId = value;
    }

    public String getConceptRefType {
        return this.conceptRefType;
    }
    public void setConceptRefType {
        conceptRefType = value;
    }

    /**
     * The ID of the ConceptPropertyFamily
     */
    public Integer getConceptPropertyFamilyId {
        return this.conceptPropertyFamilyId;
    }
    public void setConceptPropertyFamilyId {
        conceptPropertyFamilyId = value;
    }

    public Boolean getIsPropagating {
        return this.isPropagating;
    }
    public void setIsPropagating {
        isPropagating = value;
    }

    public String getDbColumnName {
        return this.dbColumnName;
    }
    public void setDbColumnName {
        dbColumnName = value;
    }

    public Boolean getIsIdentity {
        return this.isIdentity;
    }
    public void setIsIdentity {
        isIdentity = value;
    }

    public Boolean getIsCoreField {
        return this.isCoreField;
    }
    public void setIsCoreField {
        isCoreField = value;
    }

    public String getFieldFamilyName {
        return this.fieldFamilyName;
    }
    public void setFieldFamilyName {
        fieldFamilyName = value;
    }

    public Boolean getIsUpdatable {
        return this.isUpdatable;
    }
    public void setIsUpdatable {
        isUpdatable = value;
    }

    public String getFieldLabel {
        return this.fieldLabel;
    }
    public void setFieldLabel {
        fieldLabel = value;
    }

    public Boolean getIsScalarFieldToSerialiseInPersistenceModel {
        return this.isScalarFieldToSerialiseInPersistenceModel;
    }
    public void setIsScalarFieldToSerialiseInPersistenceModel {
        isScalarFieldToSerialiseInPersistenceModel = value;
    }

    public Boolean getIsScalarFieldToSerialiseInDomainModel {
        return this.isScalarFieldToSerialiseInDomainModel;
    }
    public void setIsScalarFieldToSerialiseInDomainModel {
        isScalarFieldToSerialiseInDomainModel = value;
    }

    public Boolean getIsSeqNoField {
        return this.isSeqNoField;
    }
    public void setIsSeqNoField {
        isSeqNoField = value;
    }

    public Boolean getIsDiscriminatorField {
        return this.isDiscriminatorField;
    }
    public void setIsDiscriminatorField {
        isDiscriminatorField = value;
    }

    public Boolean getIsXmlAttribute {
        return this.isXmlAttribute;
    }
    public void setIsXmlAttribute {
        isXmlAttribute = value;
    }

    public Boolean getIsReferenceToChildEntity {
        return this.isReferenceToChildEntity;
    }
    public void setIsReferenceToChildEntity {
        isReferenceToChildEntity = value;
    }

    public String getParentQualifier {
        return this.parentQualifier;
    }
    public void setParentQualifier {
        parentQualifier = value;
    }

    public String getChildQualifier {
        return this.childQualifier;
    }
    public void setChildQualifier {
        childQualifier = value;
    }

    public Integer getMinChildOccurrences {
        return this.minChildOccurrences;
    }
    public void setMinChildOccurrences {
        minChildOccurrences = value;
    }

    public Integer getMaxChildOccurrences {
        return this.maxChildOccurrences;
    }
    public void setMaxChildOccurrences {
        maxChildOccurrences = value;
    }

    public String getChildVerbPhrase {
        return this.childVerbPhrase;
    }
    public void setChildVerbPhrase {
        childVerbPhrase = value;
    }

    public String getParentVerbPhrase {
        return this.parentVerbPhrase;
    }
    public void setParentVerbPhrase {
        parentVerbPhrase = value;
    }

    public Integer getChildPropertySeq {
        return this.childPropertySeq;
    }
    public void setChildPropertySeq {
        childPropertySeq = value;
    }

    public String getChildCollectionName {
        return this.childCollectionName;
    }
    public void setChildCollectionName {
        childCollectionName = value;
    }

    public String getChildItemName {
        return this.childItemName;
    }
    public void setChildItemName {
        childItemName = value;
    }

    public String getChildPropertyDescription {
        return this.childPropertyDescription;
    }
    public void setChildPropertyDescription {
        childPropertyDescription = value;
    }

    public String getSelectorType {
        return this.selectorType;
    }
    public void setSelectorType {
        selectorType = value;
    }

    public String getRelationshipType {
        return this.relationshipType;
    }
    public void setRelationshipType {
        relationshipType = value;
    }

    public Boolean getOutputExplicitXmlCollection {
        return this.outputExplicitXmlCollection;
    }
    public void setOutputExplicitXmlCollection {
        outputExplicitXmlCollection = value;
    }

    public Boolean getIsSerialisedUsingScalarFieldInDomainModel {
        return this.isSerialisedUsingScalarFieldInDomainModel;
    }
    public void setIsSerialisedUsingScalarFieldInDomainModel {
        isSerialisedUsingScalarFieldInDomainModel = value;
    }

    public String getScalarFieldNameInDomainModel {
        return this.scalarFieldNameInDomainModel;
    }
    public void setScalarFieldNameInDomainModel {
        scalarFieldNameInDomainModel = value;
    }

    public String getExampleValueAsString {
        return this.exampleValueAsString;
    }
    public void setExampleValueAsString {
        exampleValueAsString = value;
    }

    public String getRelationshipName {
        return this.relationshipName;
    }
    public void setRelationshipName {
        relationshipName = value;
    }

    public String getDbForeignKeyName {
        return this.dbForeignKeyName;
    }
    public void setDbForeignKeyName {
        dbForeignKeyName = value;
    }

    public String getParentIndexName {
        return this.parentIndexName;
    }
    public void setParentIndexName {
        parentIndexName = value;
    }

    public String getForeignKeySurrogateKeyFieldName {
        return this.foreignKeySurrogateKeyFieldName;
    }
    public void setForeignKeySurrogateKeyFieldName {
        foreignKeySurrogateKeyFieldName = value;
    }

    public String getChildPropertyName {
        return this.childPropertyName;
    }
    public void setChildPropertyName {
        childPropertyName = value;
    }

    public Boolean getIsNullable {
        return this.isNullable;
    }
    public void setIsNullable {
        isNullable = value;
    }

    public Integer getPropertySeq {
        return this.propertySeq;
    }
    public void setPropertySeq {
        propertySeq = value;
    }

    /**
     * the associated Concept object
     * that is referenced using the ConceptId property
     */
    public Concept getConcept {
        return this.concept;
    }
    public void setConcept {
        concept = value;
    }

    /**
     * the Referenced Concept object
     * that is referenced using the ReferencedConceptId property
     */
    public Concept getReferencedConcept {
        return this.referencedConcept;
    }
    public void setReferencedConcept {
        referencedConcept = value;
    }

    /**
     * the associated ConceptPropertyFamily object
     * that is referenced using the ConceptPropertyFamilyId property
     */
    public ConceptPropertyFamily getPropertyFamily {
        return this.propertyFamily;
    }
    public void setPropertyFamily {
        propertyFamily = value;
    }

    // end of region
}
