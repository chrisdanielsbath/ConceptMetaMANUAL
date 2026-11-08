/****************************
 * ConceptUniqueKeyPropertyFamilyRef.java
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
 * A record that associates a given unique key with a particular family of properties, signifying that the family of properties is relevant to that unique key
 */
@Entity
@Table(name = "ConceptUniqueKeyPropertyFamilyRef", schema = "dbo")
public class ConceptUniqueKeyPropertyFamilyRef {

    // Instance Variables region

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "ConceptUniqueKeyPropertyFamilyRefId")
    private Integer conceptUniqueKeyPropertyFamilyRefId;

    @Column(name = "ConceptModelId")
    private Integer conceptModelId;

    @Column(name = "ModelName")
    private String modelName;

    @Column(name = "ConceptId")
    private Integer conceptId;

    @Column(name = "ConceptName")
    private String conceptName;

    @Column(name = "ConceptUniqueKeyId")
    private Integer conceptUniqueKeyId;

    @Column(name = "UniqueKeyName")
    private String uniqueKeyName;

    @Column(name = "ConceptPropertyFamilyId")
    private Integer conceptPropertyFamilyId;

    @Column(name = "PropertyFamilyName")
    private String propertyFamilyName;

    @Column(name = "SeqNo")
    private Integer seqNo;

    @ManyToOne(fetch=FetchType.LAZY)
    @JoinColumn(name = "ConceptUniqueKeyId")
    private ConceptUniqueKey conceptUniqueKey;

    @ManyToOne(fetch=FetchType.LAZY)
    @JoinColumn(name = "ConceptPropertyFamilyId")
    private ConceptPropertyFamily conceptPropertyFamily;

    // end of region

    // Instance Properties region

    /**
     * The ID of the ConceptUniqueKeyPropertyFamilyRef
     */
    public Integer getConceptUniqueKeyPropertyFamilyRefId {
        return this.conceptUniqueKeyPropertyFamilyRefId;
    }
    public void setConceptUniqueKeyPropertyFamilyRefId {
        conceptUniqueKeyPropertyFamilyRefId = value;
    }

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
     * The ID of the ConceptPropertyFamily
     */
    public Integer getConceptPropertyFamilyId {
        return this.conceptPropertyFamilyId;
    }
    public void setConceptPropertyFamilyId {
        conceptPropertyFamilyId = value;
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
     * the associated ConceptUniqueKey object
     * that is referenced using the ConceptUniqueKeyId property
     */
    public ConceptUniqueKey getConceptUniqueKey {
        return this.conceptUniqueKey;
    }
    public void setConceptUniqueKey {
        conceptUniqueKey = value;
    }

    /**
     * the associated ConceptPropertyFamily object
     * that is referenced using the ConceptPropertyFamilyId property
     */
    public ConceptPropertyFamily getConceptPropertyFamily {
        return this.conceptPropertyFamily;
    }
    public void setConceptPropertyFamily {
        conceptPropertyFamily = value;
    }

    // end of region
}
