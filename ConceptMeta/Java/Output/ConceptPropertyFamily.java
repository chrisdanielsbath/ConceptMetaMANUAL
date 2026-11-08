/****************************
 * ConceptPropertyFamily.java
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
 * A family of properties
 */
@Entity
@Table(name = "ConceptPropertyFamily", schema = "dbo")
public class ConceptPropertyFamily {

    // Instance Variables region

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "ConceptPropertyFamilyId")
    private Integer conceptPropertyFamilyId;

    @Column(name = "ConceptModelId")
    private Integer conceptModelId;

    @Column(name = "ModelName")
    private String modelName;

    @Column(name = "ConceptId")
    private Integer conceptId;

    @Column(name = "ConceptName")
    private String conceptName;

    @Column(name = "PropertyFamilyName")
    private String propertyFamilyName;

    @Column(name = "SeqNo")
    private Integer seqNo;

    @ManyToOne(fetch=FetchType.LAZY)
    @JoinColumn(name = "ConceptId")
    private Concept concept;

    @OneToMany(fetch=FetchType.LAZY, mappedBy="conceptPropertyFamily")
    private Set<ConceptRef> properties;

    @OneToMany(fetch=FetchType.LAZY, mappedBy="conceptPropertyFamily")
    private Set<ConceptSubTypePropertyFamilyRef> propertyFamilyRefs;

    @OneToMany(fetch=FetchType.LAZY, mappedBy="conceptPropertyFamily")
    private Set<ConceptUniqueKeyPropertyFamilyRef> uniqueKeyPropertyFamilyRefs;

    // end of region

    // Instance Properties region

    /**
     * The ID of the ConceptPropertyFamily
     */
    public Integer getConceptPropertyFamilyId {
        return this.conceptPropertyFamilyId;
    }
    public void setConceptPropertyFamilyId {
        conceptPropertyFamilyId = value;
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

    public String getPropertyFamilyName {
        return this.propertyFamilyName;
    }
    public void setPropertyFamilyName {
        propertyFamilyName = value;
    }

    /**
     * Sequence number
     */
    public Integer getSeqNo {
        return this.seqNo;
    }
    public void setSeqNo {
        seqNo = value;
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
     * the set of child ConceptRef objects
     */
    public Set<ConceptRef> getProperties {
        return this.conceptRef;
    }
    public void setProperties {
        conceptRef = value;
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
     * the set of child ConceptUniqueKeyPropertyFamilyRef objects
     */
    public Set<ConceptUniqueKeyPropertyFamilyRef> getUniqueKeyPropertyFamilyRefs {
        return this.conceptUniqueKeyPropertyFamilyRef;
    }
    public void setUniqueKeyPropertyFamilyRefs {
        conceptUniqueKeyPropertyFamilyRef = value;
    }

    // end of region
}
