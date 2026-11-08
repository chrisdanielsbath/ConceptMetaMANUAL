/****************************
 * ConceptSubType.java
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
 * A specialised variety of an entity
 */
@Entity
@Table(name = "ConceptSubType", schema = "dbo")
public class ConceptSubType {

    // Instance Variables region

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "ConceptSubTypeId")
    private Integer conceptSubTypeId;

    @Column(name = "ConceptModelId")
    private Integer conceptModelId;

    @Column(name = "ModelName")
    private String modelName;

    @Column(name = "ConceptId")
    private Integer conceptId;

    @Column(name = "ConceptName")
    private String conceptName;

    @Column(name = "SubTypeName")
    private String subTypeName;

    @ManyToOne(fetch=FetchType.LAZY)
    @JoinColumn(name = "ConceptId")
    private Concept concept;

    @OneToMany(fetch=FetchType.LAZY, mappedBy="conceptSubType")
    private Set<ConceptSubTypePropertyFamilyRef> propertyFamilyRefs;

    @OneToMany(fetch=FetchType.LAZY, mappedBy="conceptSubType")
    private Set<Concept> subTypeRefs;

    // end of region

    // Instance Properties region

    /**
     * The ID of the ConceptSubType
     */
    public Integer getConceptSubTypeId {
        return this.conceptSubTypeId;
    }
    public void setConceptSubTypeId {
        conceptSubTypeId = value;
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

    public String getSubTypeName {
        return this.subTypeName;
    }
    public void setSubTypeName {
        subTypeName = value;
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
     * the set of child ConceptSubTypePropertyFamilyRef objects
     */
    public Set<ConceptSubTypePropertyFamilyRef> getPropertyFamilyRefs {
        return this.conceptSubTypePropertyFamilyRef;
    }
    public void setPropertyFamilyRefs {
        conceptSubTypePropertyFamilyRef = value;
    }

    /**
     * the set of child Concept objects
     */
    public Set<Concept> getSubTypeRefs {
        return this.concept;
    }
    public void setSubTypeRefs {
        concept = value;
    }

    // end of region
}
