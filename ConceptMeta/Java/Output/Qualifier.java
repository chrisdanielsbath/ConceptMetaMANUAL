/****************************
 * Qualifier.java
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
 * A prefix that can be placed before the name of the current entity to specify the role it plays
 */
@Entity
@Table(name = "Qualifier", schema = "dbo")
public class Qualifier {

    // Instance Variables region

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "QualifierId")
    private Integer qualifierId;

    @Column(name = "ConceptModelId")
    private Integer conceptModelId;

    @Column(name = "ModelName")
    private String modelName;

    @Column(name = "ConceptId")
    private Integer conceptId;

    @Column(name = "ConceptName")
    private String conceptName;

    @Column(name = "ItemValue")
    private String itemValue;

    @Column(name = "SeqNo")
    private Integer seqNo;

    @ManyToOne(fetch=FetchType.LAZY)
    @JoinColumn(name = "ConceptId")
    private Concept concept;

    // end of region

    // Instance Properties region

    /**
     * The ID of the Qualifier
     */
    public Integer getQualifierId {
        return this.qualifierId;
    }
    public void setQualifierId {
        qualifierId = value;
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

    public String getItemValue {
        return this.itemValue;
    }
    public void setItemValue {
        itemValue = value;
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

    // end of region
}
