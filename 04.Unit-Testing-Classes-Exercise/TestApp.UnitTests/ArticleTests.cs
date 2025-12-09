using NUnit.Framework;

using System;
using System.Collections;

namespace TestApp.UnitTests;

public class ArticleTests
{
    private Article _article;

    [SetUp]
    public void SetUp()
    {
        _article = new Article();
    }

    [Test]
    public void Test_AddArticles_ReturnsArticleWithCorrectData()
    {
        // Arrange
        string[] articles = new string[] 
        { 
            "Electric_car Future... Elon_Musk",
            "Social_media Facebok... Diyan_Apostolov",
            "Title3 Content3 Author3" 
        };

        // Act
        Article result = _article.AddArticles(articles);

        // Assert
        Assert.That(result.ArticleList, Has.Count.EqualTo(3));

        Assert.That(result.ArticleList[0].Title, Is.EqualTo("Electric_car"));
        Assert.That(result.ArticleList[0].Content, Is.EqualTo("Future..."));
        Assert.That(result.ArticleList[0].Author, Is.EqualTo("Elon_Musk"));

        Assert.That(result.ArticleList[1].Content, Is.EqualTo("Facebok..."));

        Assert.That(result.ArticleList[2].Author, Is.EqualTo("Author3"));
    }

    [Test]
    public void Test_GetArticleList_SortsArticlesByTitle()
    {
        // Arrange
        string[] articles = new string[]
        {
            "Title3 Content3 Author3",
            "Social_media Facebok... Diyan_Apostolov",
            "Electric_car Future... Elon_Musk"
        };
        string printCriteria = "title";

        _article = _article.AddArticles(articles);

        string exected = $"Electric_car - Future...: Elon_Musk{Environment.NewLine}" +
                         $"Social_media - Facebok...: Diyan_Apostolov{Environment.NewLine}" +
                         $"Title3 - Content3: Author3";

        // Act
        string result = _article.GetArticleList(_article, printCriteria);

        // Assert
        Assert.That(result, Is.EqualTo(exected));

    }

    [Test]
    public void Test_GetArticleList_ReturnsEmptyString_WhenInvalidPrintCriteria()
    {
        // Arrange
        string[] articles = new string[]
        {
            "Title3 Content3 Author3",
            "Social_media Facebok... Diyan_Apostolov",
            "Electric_car Future... Elon_Musk"
        };

        string printCriteria = "invalidCriteria";

        _article = _article.AddArticles(articles);

        // Act
        string result = _article.GetArticleList(_article, printCriteria);

        // Assert
        Assert.That(result, Is.Empty);
    }

    //BONUS TEST - NOT FOR JUDGE
    [Test]
    public void Test_GetArticleList_SortsArticlesByAuthor()
    {
        // Arrange
        string[] articles = new string[]
        {
            "Electric_car Future... Elon_Musk",
            "Social_media Facebok... Diyan_Apostolov",
            "Title3 Content3 Author3"
        };
        string printCriteria = "author";

        _article = _article.AddArticles(articles);

        string exected = $"Title3 - Content3: Author3{Environment.NewLine}" +
                         $"Social_media - Facebok...: Diyan_Apostolov{Environment.NewLine}" +
                         $"Electric_car - Future...: Elon_Musk";

        // Act
        string result = _article.GetArticleList(_article, printCriteria);

        // Assert
        Assert.That(result, Is.EqualTo(exected));

    }
}
