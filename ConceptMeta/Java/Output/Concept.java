/****************************
 * Concept.java
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
 * An entity, a domain, a unique key or a sub type
 */
@Entity
@Table(name = "Concept", schema = "dbo")
public class Concept {

    // Instance Variables region

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "ConceptId")
    private Integer conceptId;

    @Column(name = "ConceptModelId")
    private Integer conceptModelId;

    @Column(name = "ModelName")
    private String modelName;

    @Column(name = "ConceptName")
    private String conceptName;

    @Column(name = "ConceptDescription")
    private String conceptDescription;

    @Column(name = "ConceptType")
    private String conceptType;

    @Column(name = "DataTypeId")
    private Integer dataTypeId;

    @Column(name = "DataTypeName")
    private String dataTypeName;

    @Column(name = "EnumerationId")
    private Integer enumerationId;

    @Column(name = "EnumerationName")
    private String enumerationName;

    @Column(name = "BasedOnConceptId")
    private Integer basedOnConceptId;

    @Column(name = "BasedOnConceptName")
    private String basedOnConceptName;

    @Column(name = "ExampleValueAsString")
    private String exampleValueAsString;

    @Column(name = "MinLength")
    private Integer minLength;

    @Column(name = "MaxLength")
    private Integer maxLength;

    @Column(name = "MinValue")
    private Double minValue;

    @Column(name = "MaxValue")
    private Double maxValue;

    @Column(name = "TotalDigits")
    private Integer totalDigits;

    @Column(name = "DecimalPlaces")
    private Integer decimalPlaces;

    @Column(name = "DatePrecision")
    private Integer datePrecision;

    @Column(name = "DbSchemaName")
    private String dbSchemaName;

    @Column(name = "DbTableName")
    private String dbTableName;

    @Column(name = "IsCollectionItem")
    private Boolean isCollectionItem;

    @Column(name = "ToStringExpression")
    private String toStringExpression;

    @Column(name = "IsCreatable")
    private Boolean isCreatable;

    @Column(name = "IsUpdatable")
    private Boolean isUpdatable;

    @Column(name = "IsDeletable")
    private Boolean isDeletable;

    @Column(name = "SurrogateKeyFieldName")
    private String surrogateKeyFieldName;

    @Column(name = "PrimaryKeyName")
    private String primaryKeyName;

    @Column(name = "AlternateKeyName")
    private String alternateKeyName;

    @Column(name = "ReferencedConceptId")
    private Integer referencedConceptId;

    @Column(name = "ReferencedConceptName")
    private String referencedConceptName;

    @Column(name = "ReferencedConceptUniqueKeyId")
    private Integer referencedConceptUniqueKeyId;

    @Column(name = "ReferencedUniqueKeyName")
    private String referencedUniqueKeyName;

    @Column(name = "SpecialisedConceptId")
    private Integer specialisedConceptId;

    @Column(name = "SpecialisedConceptName")
    private String specialisedConceptName;

    @Column(name = "SpecialisedConceptSubTypeId")
    private Integer specialisedConceptSubTypeId;

    @Column(name = "SpecialisedSubTypeName")
    private String specialisedSubTypeName;

    @ManyToOne(fetch=FetchType.LAZY)
    @JoinColumn(name = "ConceptModelId")
    private ConceptModel conceptModel;

    @ManyToOne(fetch=FetchType.LAZY)
    @JoinColumn(name = "DataTypeId")
    private DataType dataType;

    @ManyToOne(fetch=FetchType.LAZY)
    @JoinColumn(name = "EnumerationId")
    private Enumeration enumeration;

    @ManyToOne(fetch=FetchType.LAZY)
    @JoinColumn(name = "BasedOnConceptId")
    private Concept basedOnConcept;

    @ManyToOne(fetch=FetchType.LAZY)
    @JoinColumn(name = "ReferencedConceptId")
    private Concept referencedConcept;

    @ManyToOne(fetch=FetchType.LAZY)
    @JoinColumn(name = "ReferencedConceptUniqueKeyId")
    private ConceptUniqueKey referencedUniqueKey;

    @ManyToOne(fetch=FetchType.LAZY)
    @JoinColumn(name = "SpecialisedConceptId")
    private Concept specialisedConcept;

    @ManyToOne(fetch=FetchType.LAZY)
    @JoinColumn(name = "SpecialisedConceptSubTypeId")
    private ConceptSubType specialisedSubType;

    @OneToMany(fetch=FetchType.LAZY, mappedBy="concept")
    private Set<Include> includes;

    @OneToMany(fetch=FetchType.LAZY, mappedBy="concept")
    private Set<Qualifier> qualifiers;

    @OneToMany(fetch=FetchType.LAZY, mappedBy="concept")
    private Set<ConceptPropertyFamily> propertyFamilies;

    @OneToMany(fetch=FetchType.LAZY, mappedBy="concept")
    private Set<ConceptUniqueKey> uniqueKeys;

    @OneToMany(fetch=FetchType.LAZY, mappedBy="concept")
    private Set<ConceptSubType> subTypes;

    @OneToMany(fetch=FetchType.LAZY, mappedBy="concept")
    private Set<ConceptRef> properties;

    @OneToMany(fetch=FetchType.LAZY, mappedBy="concept")
    private Set<Concept> derivedConcepts;

    @OneToMany(fetch=FetchType.LAZY, mappedBy="concept")
    private Set<ConceptRef> referencedByProperties;

    @OneToMany(fetch=FetchType.LAZY, mappedBy="concept")
    private Set<Concept> referencedByConcepts;

    @OneToMany(fetch=FetchType.LAZY, mappedBy="concept")
    private Set<Concept> specialisedByConcepts;

    // end of region

    // Instance Properties region

    /**
     * The ID of the Concept
     */
    public Integer getConceptId {
        return this.conceptId;
    }
    public void setConceptId {
        conceptId = value;
    }

    /**
     * The ID of the ConceptModel
     */
    public Integer getConceptModelId {
        return this.conceptModelId;
    }
    public void setConceptModelId {
        conceptModelId = value;
    }

    public String getConceptName {
        return this.conceptName;
    }
    public void setConceptName {
        conceptName = value;
    }

    public String getConceptDescription {
        return this.conceptDescription;
    }
    public void setConceptDescription {
        conceptDescription = value;
    }

    public String getConceptType {
        return this.conceptType;
    }
    public void setConceptType {
        conceptType = value;
    }

    /**
     * The ID of the DataType
     */
    public Integer getDataTypeId {
        return this.dataTypeId;
    }
    public void setDataTypeId {
        dataTypeId = value;
    }

    /**
     * The ID of the Enumeration
     */
    public Integer getEnumerationId {
        return this.enumerationId;
    }
    public void setEnumerationId {
        enumerationId = value;
    }

    /**
     * The ID of the BasedOn Concept
     */
    public Integer getBasedOnConceptId {
        return this.basedOnConceptId;
    }
    public void setBasedOnConceptId {
        basedOnConceptId = value;
    }

    public String getExampleValueAsString {
        return this.exampleValueAsString;
    }
    public void setExampleValueAsString {
        exampleValueAsString = value;
    }

    public Integer getMinLength {
        return this.minLength;
    }
    public void setMinLength {
        minLength = value;
    }

    public Integer getMaxLength {
        return this.maxLength;
    }
    public void setMaxLength {
        maxLength = value;
    }

    public Double getMinValue {
        return this.minValue;
    }
    public void setMinValue {
        minValue = value;
    }

    public Double getMaxValue {
        return this.maxValue;
    }
    public void setMaxValue {
        maxValue = value;
    }

    public Integer getTotalDigits {
        return this.totalDigits;
    }
    public void setTotalDigits {
        totalDigits = value;
    }

    public Integer getDecimalPlaces {
        return this.decimalPlaces;
    }
    public void setDecimalPlaces {
        decimalPlaces = value;
    }

    public Integer getDatePrecision {
        return this.datePrecision;
    }
    public void setDatePrecision {
        datePrecision = value;
    }

    public String getDbSchemaName {
        return this.dbSchemaName;
    }
    public void setDbSchemaName {
        dbSchemaName = value;
    }

    public String getDbTableName {
        return this.dbTableName;
    }
    public void setDbTableName {
        dbTableName = value;
    }

    public Boolean getIsCollectionItem {
        return this.isCollectionItem;
    }
    public void setIsCollectionItem {
        isCollectionItem = value;
    }

    public String getToStringExpression {
        return this.toStringExpression;
    }
    public void setToStringExpression {
        toStringExpression = value;
    }

    public Boolean getIsCreatable {
        return this.isCreatable;
    }
    public void setIsCreatable {
        isCreatable = value;
    }

    public Boolean getIsUpdatable {
        return this.isUpdatable;
    }
    public void setIsUpdatable {
        isUpdatable = value;
    }

    public Boolean getIsDeletable {
        return this.isDeletable;
    }
    public void setIsDeletable {
        isDeletable = value;
    }

    public String getSurrogateKeyFieldName {
        return this.surrogateKeyFieldName;
    }
    public void setSurrogateKeyFieldName {
        surrogateKeyFieldName = value;
    }

    public String getPrimaryKeyName {
        return this.primaryKeyName;
    }
    public void setPrimaryKeyName {
        primaryKeyName = value;
    }

    public String getAlternateKeyName {
        return this.alternateKeyName;
    }
    public void setAlternateKeyName {
        alternateKeyName = value;
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

    /**
     * The ID of the Referenced ConceptUniqueKey
     */
    public Integer getReferencedConceptUniqueKeyId {
        return this.referencedConceptUniqueKeyId;
    }
    public void setReferencedConceptUniqueKeyId {
        referencedConceptUniqueKeyId = value;
    }

    /**
     * The ID of the Specialised Concept
     */
    public Integer getSpecialisedConceptId {
        return this.specialisedConceptId;
    }
    public void setSpecialisedConceptId {
        specialisedConceptId = value;
    }

    /**
     * The ID of the Specialised ConceptSubType
     */
    public Integer getSpecialisedConceptSubTypeId {
        return this.specialisedConceptSubTypeId;
    }
    public void setSpecialisedConceptSubTypeId {
        specialisedConceptSubTypeId = value;
    }

    /**
     * the associated ConceptModel object
     * that is referenced using the ConceptModelId property
     */
    public ConceptModel getConceptModel {
        return this.conceptModel;
    }
    public void setConceptModel {
        conceptModel = value;
    }

    /**
     * the associated DataType object
     * that is referenced using the DataTypeId property
     */
    public DataType getDataType {
        return this.dataType;
    }
    public void setDataType {
        dataType = value;
    }

    /**
     * the associated Enumeration object
     * that is referenced using the EnumerationId property
     */
    public Enumeration getEnumeration {
        return this.enumeration;
    }
    public void setEnumeration {
        enumeration = value;
    }

    /**
     * the BasedOn Concept object
     * that is referenced using the BasedOnConceptId property
     */
    public Concept getBasedOnConcept {
        return this.basedOnConcept;
    }
    public void setBasedOnConcept {
        basedOnConcept = value;
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
     * the Referenced ConceptUniqueKey object
     * that is referenced using the ReferencedConceptUniqueKeyId property
     */
    public ConceptUniqueKey getReferencedUniqueKey {
        return this.referencedUniqueKey;
    }
    public void setReferencedUniqueKey {
        referencedUniqueKey = value;
    }

    /**
     * the Specialised Concept object
     * that is referenced using the SpecialisedConceptId property
     */
    public Concept getSpecialisedConcept {
        return this.specialisedConcept;
    }
    public void setSpecialisedConcept {
        specialisedConcept = value;
    }

    /**
     * the Specialised ConceptSubType object
     * that is referenced using the SpecialisedConceptSubTypeId property
     */
    public ConceptSubType getSpecialisedSubType {
        return this.specialisedSubType;
    }
    public void setSpecialisedSubType {
        specialisedSubType = value;
    }

    /**
     * the set of child Include objects
     */
    public Set<Include> getIncludes {
        return this.include;
    }
    public void setIncludes {
        include = value;
    }

    /**
     * the set of child Qualifier objects
     */
    public Set<Qualifier> getQualifiers {
        return this.qualifier;
    }
    public void setQualifiers {
        qualifier = value;
    }

    /**
     * the set of child ConceptPropertyFamily objects
     */
    public Set<ConceptPropertyFamily> getPropertyFamilies {
        return this.conceptPropertyFamily;
    }
    public void setPropertyFamilies {
        conceptPropertyFamily = value;
    }

    /**
     * the set of child ConceptUniqueKey objects
     */
    public Set<ConceptUniqueKey> getUniqueKeys {
        return this.conceptUniqueKey;
    }
    public void setUniqueKeys {
        conceptUniqueKey = value;
    }

    /**
     * the set of child ConceptSubType objects
     */
    public Set<ConceptSubType> getSubTypes {
        return this.conceptSubType;
    }
    public void setSubTypes {
        conceptSubType = value;
    }

    /**
     * the set of child ConceptRef objects
     */
    public Set<ConceptRef> getProperties {
        return this.conceptRef;
    }
    public void setProperties {
        conceptRef = value;
    }

    /**
     * the set of child Concept objects
     */
    public Set<Concept> getDerivedConcepts {
        return this.concept;
    }
    public void setDerivedConcepts {
        concept = value;
    }

    /**
     * the set of ReferencedBy ConceptRef objects
     */
    public Set<ConceptRef> getReferencedByProperties {
        return this.conceptRef;
    }
    public void setReferencedByProperties {
        conceptRef = value;
    }

    /**
     * the set of ReferencedBy Concept objects
     */
    public Set<Concept> getReferencedByConcepts {
        return this.concept;
    }
    public void setReferencedByConcepts {
        concept = value;
    }

    /**
     * the set of SpecialisedBy Concept objects
     */
    public Set<Concept> getSpecialisedByConcepts {
        return this.concept;
    }
    public void setSpecialisedByConcepts {
        concept = value;
    }

    // end of region
}
