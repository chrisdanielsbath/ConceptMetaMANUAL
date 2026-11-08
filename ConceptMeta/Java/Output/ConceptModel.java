/****************************
 * ConceptModel.java
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
 * A model, made primarily of scalar concepts and object concepts
 */
@Entity
@Table(name = "ConceptModel", schema = "dbo")
public class ConceptModel {

    // Instance Variables region

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "ConceptModelId")
    private Integer conceptModelId;

    @Column(name = "ModelName")
    private String modelName;

    @Column(name = "DefaultStringLength")
    private Integer defaultStringLength;

    @OneToMany(fetch=FetchType.LAZY, mappedBy="conceptModel")
    private Set<DataType> dataTypes;

    @OneToMany(fetch=FetchType.LAZY, mappedBy="conceptModel")
    private Set<Enumeration> enumerations;

    @OneToMany(fetch=FetchType.LAZY, mappedBy="conceptModel")
    private Set<Concept> concepts;

    // end of region

    // Instance Properties region

    /**
     * The ID of the ConceptModel
     */
    public Integer getConceptModelId {
        return this.conceptModelId;
    }
    public void setConceptModelId {
        conceptModelId = value;
    }

    public String getModelName {
        return this.modelName;
    }
    public void setModelName {
        modelName = value;
    }

    public Integer getDefaultStringLength {
        return this.defaultStringLength;
    }
    public void setDefaultStringLength {
        defaultStringLength = value;
    }

    /**
     * the set of child DataType objects
     */
    public Set<DataType> getDataTypes {
        return this.dataType;
    }
    public void setDataTypes {
        dataType = value;
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
