/****************************
 * DataType.java
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
 * A data type
 */
@Entity
@Table(name = "DataType", schema = "dbo")
public class DataType {

    // Instance Variables region

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "DataTypeId")
    private Integer dataTypeId;

    @Column(name = "ConceptModelId")
    private Integer conceptModelId;

    @Column(name = "ModelName")
    private String modelName;

    @Column(name = "DataTypeName")
    private String dataTypeName;

    @Column(name = "SqlServerDataType")
    private String sqlServerDataType;

    @Column(name = "OracleDataType")
    private String oracleDataType;

    @Column(name = "MySqlDataType")
    private String mySqlDataType;

    @Column(name = "MongoDbDataType")
    private String mongoDbDataType;

    @Column(name = "DotNetDataType")
    private String dotNetDataType;

    @Column(name = "JavaDataType")
    private String javaDataType;

    @Column(name = "XmlDataType")
    private String xmlDataType;

    @Column(name = "ExampleValueAsString")
    private String exampleValueAsString;

    @Column(name = "JsonDataType")
    private String jsonDataType;

    @Column(name = "JsonFormat")
    private String jsonFormat;

    @Column(name = "OpenApiDataType")
    private String openApiDataType;

    @Column(name = "OpenApiFormat")
    private String openApiFormat;

    @Column(name = "ErsDataType")
    private String ersDataType;

    @Column(name = "BasicDataType")
    private String basicDataType;

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

    @Column(name = "HasLength")
    private Boolean hasLength;

    @Column(name = "HasTotalDigits")
    private Boolean hasTotalDigits;

    @Column(name = "HasDecimalPlaces")
    private Boolean hasDecimalPlaces;

    @Column(name = "HasIdentity")
    private Boolean hasIdentity;

    @Column(name = "HasDatePrecision")
    private Boolean hasDatePrecision;

    @ManyToOne(fetch=FetchType.LAZY)
    @JoinColumn(name = "ConceptModelId")
    private ConceptModel conceptModel;

    @OneToMany(fetch=FetchType.LAZY, mappedBy="dataType")
    private Set<Concept> concepts;

    @OneToMany(fetch=FetchType.LAZY, mappedBy="dataType")
    private Set<Enumeration> enumerations;

    // end of region

    // Instance Properties region

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
     * The ID of the ConceptModel
     */
    public Integer getConceptModelId {
        return this.conceptModelId;
    }
    public void setConceptModelId {
        conceptModelId = value;
    }

    public String getDataTypeName {
        return this.dataTypeName;
    }
    public void setDataTypeName {
        dataTypeName = value;
    }

    public String getSqlServerDataType {
        return this.sqlServerDataType;
    }
    public void setSqlServerDataType {
        sqlServerDataType = value;
    }

    public String getOracleDataType {
        return this.oracleDataType;
    }
    public void setOracleDataType {
        oracleDataType = value;
    }

    public String getMySqlDataType {
        return this.mySqlDataType;
    }
    public void setMySqlDataType {
        mySqlDataType = value;
    }

    public String getMongoDbDataType {
        return this.mongoDbDataType;
    }
    public void setMongoDbDataType {
        mongoDbDataType = value;
    }

    public String getDotNetDataType {
        return this.dotNetDataType;
    }
    public void setDotNetDataType {
        dotNetDataType = value;
    }

    public String getJavaDataType {
        return this.javaDataType;
    }
    public void setJavaDataType {
        javaDataType = value;
    }

    public String getXmlDataType {
        return this.xmlDataType;
    }
    public void setXmlDataType {
        xmlDataType = value;
    }

    public String getExampleValueAsString {
        return this.exampleValueAsString;
    }
    public void setExampleValueAsString {
        exampleValueAsString = value;
    }

    public String getJsonDataType {
        return this.jsonDataType;
    }
    public void setJsonDataType {
        jsonDataType = value;
    }

    public String getJsonFormat {
        return this.jsonFormat;
    }
    public void setJsonFormat {
        jsonFormat = value;
    }

    public String getOpenApiDataType {
        return this.openApiDataType;
    }
    public void setOpenApiDataType {
        openApiDataType = value;
    }

    public String getOpenApiFormat {
        return this.openApiFormat;
    }
    public void setOpenApiFormat {
        openApiFormat = value;
    }

    public String getErsDataType {
        return this.ersDataType;
    }
    public void setErsDataType {
        ersDataType = value;
    }

    public String getBasicDataType {
        return this.basicDataType;
    }
    public void setBasicDataType {
        basicDataType = value;
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

    public Boolean getHasLength {
        return this.hasLength;
    }
    public void setHasLength {
        hasLength = value;
    }

    public Boolean getHasTotalDigits {
        return this.hasTotalDigits;
    }
    public void setHasTotalDigits {
        hasTotalDigits = value;
    }

    public Boolean getHasDecimalPlaces {
        return this.hasDecimalPlaces;
    }
    public void setHasDecimalPlaces {
        hasDecimalPlaces = value;
    }

    public Boolean getHasIdentity {
        return this.hasIdentity;
    }
    public void setHasIdentity {
        hasIdentity = value;
    }

    public Boolean getHasDatePrecision {
        return this.hasDatePrecision;
    }
    public void setHasDatePrecision {
        hasDatePrecision = value;
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
     * the set of child Concept objects
     */
    public Set<Concept> getConcepts {
        return this.concept;
    }
    public void setConcepts {
        concept = value;
    }

    /**
     * the set of child Enumeration objects
     */
    public Set<Enumeration> getEnumerations {
        return this.enumeration;
    }
    public void setEnumerations {
        enumeration = value;
    }

    // end of region
}
