/****************************
 * ConceptSubTypePropertyFamilyRef.java
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
 * A record which associates a given sub type with a particular family of properties, signifying that the family is relevant to that sub type
 */
@Entity
@Table(name = "ConceptSubTypePropertyFamilyRef", schema = "dbo")
public class ConceptSubTypePropertyFamilyRef {

    // Instance Variables region

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "ConceptSubTypePropertyFamilyRefId")
    private Integer conceptSubTypePropertyFamilyRefId;

    @Column(name = "ConceptModelId")
    private Integer conceptModelId;

    @Column(name = "ModelName")
    private String modelName;

    @Column(name = "ConceptId")
    private Integer conceptId;

    @Column(name = "ConceptName")
    private String conceptName;

    @Column(name = "ConceptSubTypeId")
    private Integer conceptSubTypeId;

    @Column(name = "SubTypeName")
    private String subTypeName;

    @Column(name = "ConceptPropertyFamilyId")
    private Integer conceptPropertyFamilyId;

    @Column(name = "PropertyFamilyName")
    private String propertyFamilyName;

    @Column(name = "SeqNo")
    private Integer seqNo;

    @ManyToOne(fetch=FetchType.LAZY)
    @JoinColumn(name = "ConceptSubTypeId")
    private ConceptSubType conceptSubType;

    @ManyToOne(fetch=FetchType.LAZY)
    @JoinColumn(name = "ConceptPropertyFamilyId")
    private ConceptPropertyFamily conceptPropertyFamily;

    // end of region

    // Instance Properties region

    /**
     * The ID of the ConceptSubTypePropertyFamilyRef
     */
    public Integer getConceptSubTypePropertyFamilyRefId {
        return this.conceptSubTypePropertyFamilyRefId;
    }
    public void setConceptSubTypePropertyFamilyRefId {
        conceptSubTypePropertyFamilyRefId = value;
    }

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
     * the associated ConceptSubType object
     * that is referenced using the ConceptSubTypeId property
     */
    public ConceptSubType getConceptSubType {
        return this.conceptSubType;
    }
    public void setConceptSubType {
        conceptSubType = value;
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
