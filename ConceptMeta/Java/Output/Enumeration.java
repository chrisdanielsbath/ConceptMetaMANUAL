/****************************
 * Enumeration.java
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
 * A constrained vocabulary
 */
@Entity
@Table(name = "Enumeration", schema = "dbo")
public class Enumeration {

    // Instance Variables region

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "EnumerationId")
    private Integer enumerationId;

    @Column(name = "ConceptModelId")
    private Integer conceptModelId;

    @Column(name = "ModelName")
    private String modelName;

    @Column(name = "EnumerationName")
    private String enumerationName;

    @Column(name = "EnumerationDescription")
    private String enumerationDescription;

    @Column(name = "DataTypeId")
    private Integer dataTypeId;

    @Column(name = "DataTypeName")
    private String dataTypeName;

    @ManyToOne(fetch=FetchType.LAZY)
    @JoinColumn(name = "ConceptModelId")
    private ConceptModel conceptModel;

    @ManyToOne(fetch=FetchType.LAZY)
    @JoinColumn(name = "DataTypeId")
    private DataType dataType;

    @OneToMany(fetch=FetchType.LAZY, mappedBy="enumeration")
    private Set<EnumerationMember> enumeratedValues;

    @OneToMany(fetch=FetchType.LAZY, mappedBy="enumeration")
    private Set<Concept> concepts;

    // end of region

    // Instance Properties region

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
     * The ID of the ConceptModel
     */
    public Integer getConceptModelId {
        return this.conceptModelId;
    }
    public void setConceptModelId {
        conceptModelId = value;
    }

    public String getEnumerationName {
        return this.enumerationName;
    }
    public void setEnumerationName {
        enumerationName = value;
    }

    public String getEnumerationDescription {
        return this.enumerationDescription;
    }
    public void setEnumerationDescription {
        enumerationDescription = value;
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
     * the set of child EnumerationMember objects
     */
    public Set<EnumerationMember> getEnumeratedValues {
        return this.enumerationMember;
    }
    public void setEnumeratedValues {
        enumerationMember = value;
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

    // end of region
}
