/****************************
 * ConceptUniqueKey.java
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
 * A unique key index that can be used to uniquely identify objects of a particular type
 */
@Entity
@Table(name = "ConceptUniqueKey", schema = "dbo")
public class ConceptUniqueKey {

    // Instance Variables region

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "ConceptUniqueKeyId")
    private Integer conceptUniqueKeyId;

    @Column(name = "ConceptModelId")
    private Integer conceptModelId;

    @Column(name = "ModelName")
    private String modelName;

    @Column(name = "ConceptId")
    private Integer conceptId;

    @Column(name = "ConceptName")
    private String conceptName;

    @Column(name = "UniqueKeyName")
    private String uniqueKeyName;

    @ManyToOne(fetch=FetchType.LAZY)
    @JoinColumn(name = "ConceptId")
    private Concept concept;

    @OneToMany(fetch=FetchType.LAZY, mappedBy="conceptUniqueKey")
    private Set<Concept> uniqueKeyRefs;

    @OneToMany(fetch=FetchType.LAZY, mappedBy="conceptUniqueKey")
    private Set<ConceptUniqueKeyPropertyFamilyRef> propertyFamilyRefs;

    // end of region

    // Instance Properties region

    /**
     * The ID of the ConceptUniqueKey
     */
    public Integer getConceptUniqueKeyId {
        return this.conceptUniqueKeyId;
    }
    public void setConceptUniqueKeyId {
        conceptUniqueKeyId = value;
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

    public String getUniqueKeyName {
        return this.uniqueKeyName;
    }
    public void setUniqueKeyName {
        uniqueKeyName = value;
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
     * the set of child Concept objects
     */
    public Set<Concept> getUniqueKeyRefs {
        return this.concept;
    }
    public void setUniqueKeyRefs {
        concept = value;
    }

    /**
     * the set of child ConceptUniqueKeyPropertyFamilyRef objects
     */
    public Set<ConceptUniqueKeyPropertyFamilyRef> getPropertyFamilyRefs {
        return this.conceptUniqueKeyPropertyFamilyRef;
    }
    public void setPropertyFamilyRefs {
        conceptUniqueKeyPropertyFamilyRef = value;
    }

    // end of region
}
