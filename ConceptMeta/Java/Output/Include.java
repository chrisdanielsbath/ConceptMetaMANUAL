/****************************
 * Include.java
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
 * A Linq expression, starting from the current entity, that defines an item to be hydrated when hydrating the current entity
 */
@Entity
@Table(name = "Include", schema = "dbo")
public class Include {

    // Instance Variables region

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "IncludeId")
    private Integer includeId;

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
     * The ID of the Include
     */
    public Integer getIncludeId {
        return this.includeId;
    }
    public void setIncludeId {
        includeId = value;
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
