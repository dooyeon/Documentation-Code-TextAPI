# Collaborative Translation Framework (CTF) Reporting API

> [!NOTE]
> As of January 1, 2018 AddTranslation() will do nothing, it will silently fail. The API response will still be success (200), but nothing will be written.
Microsoft will replace the functionality with an extended version of the Translator Hub API, which produces a custom system with your terminology, and you can invoke it using the Category ID of your custom Hub system. See [https://hub.microsofttranslator.com](https://hub.microsofttranslator.com). 

The Collaborative Translation Framework (CTF) Reporting API returns statistics and the actual content in the CTF store. This API is different from the GetTranslations() method because it: 

 * Returns the translated content and its total count only from your account (appId or Azure Marketplace account). 
 * Returns the translated content and its total count without requiring a match of the source sentence.
 * Does not return the automatic translation (machine translation).

**Endpoint**
The endpoint of the CTF Reporting API is 

http://api.microsofttranslator.com/v2/beta/ctfreporting.svc

**Methods**

| Name                                                                                      | Description                                                 |
|-------------------------------------------------------------------------------------------|-------------------------------------------------------------|
| GetUserTranslations Method                                                                | Retrieves the translations that are created by the user    |
| GetUserTranslationCounts Method                                                           | Get counts of the translations that are created by the user |


**Remarks**
These methods enable you to: 
 * Retrieve the complete set of user translations and corrections under your account ID for download.
 * Obtain the list of the frequent contributors. Ensure that the correct user name is provided in AddTranslation().
 * Build a user interface (UI) that allows your trusted users to see all available candidates, if necessary restricted to a portion of your site, based on the URI prefix.
 
>[!NOTE]
>Both the methods are relatively slow and expensive. It is recommended to use them sparingly. 

 
## GetUserTranslations Method

This method retrieves the translations that are created by the user. It provides the translations grouped by the uriPrefix, from, to, user, and minrating and maxRating request parameters. 

**Signature C#**

UserTranslation[] **GetUserTranslations** (

            string appId,
			
            string uriPrefix,
			
            string from,
			
            string to,
			
            int? minRating,
			
            int? maxRating,
			
            string user, 
			
            string category
			
            DateTime? minDateUtc,
			
            DateTime? maxDateUtc,
			
            int? skip,
			
            int? take);
            
**Parameters**

| Parameter  | Description                                                                                                                                                                                                                                         |
|------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| appId      | **Required**. If the Authorization header is used, leave the appid field empty else specify a string containing "Bearer" + " " + access token.                                                                                                          |
| uriPrefix  | **Optional**. A string containing prefix of URI of the translation.                                                                                                                                                                                     |
| from       | **Optional**. A string representing the language code of the translation text.                                                                                                                                                                          |
| to         | **Optional**. A string representing the language code to translate the text into.                                                                                                                                                                       |
| minRating  | **Optional**. An integer value representing the minimum quality rating for the,translated text. The valid value is between -10 and 10. The default value is 1.                                                                                          |
| maxRating  | **Optional**. An integer value representing the maximum quality rating for the,translated text. The valid value is between -10 and 10. The default value is 1.                                                                                          |
| user       | **Optional**. A string that is used to filter the result based on the originator,of the submission.                                                                                                                                                     |
| category   | **Optional**. A string containing the category or domain of the translation.,This parameter supports only the default option general.                                                                                                                   |
| minDateUtc | **Optional**. The date from when you want to retrieve the translations. The date,must be in the UTC format.                                                                                                                                             |
| maxDateUtc | **Optional**. The date till when you want to retrieve the translations. The date must be in the UTC format.                                                                                                                                             |
| skip       | **Optional**. The number of results that you want to skip on a page. For example, if you want the skip the first 20 rows of the results and view from the 21st result record, specify 20 for this parameter. The default value for this parameter is 0. |
| take       | **Optional**. The number of results that you want to retrieve. The maximum number of each request is 100. The default is 50.                                                                                                                            |

>[!NOTE]
>The skip and take request parameters enable pagination for a large number of result records. 

**Return Value**

The result set contains array of the **UserTranslation**. Each UserTranslation has the following elements: 

| Field          | Description                                                                      |
|----------------|----------------------------------------------------------------------------------|
| CreatedDateUtc | The creation date of the entry using AddTranslation().                           |
| From           | The source language                                                              |
| OriginalText   | The source language text that is used when submitting the request.               |
| Rating         | The rating that is applied by the submitter in the AddTranslation() method call. |
| To             | The target language                                                              |
| TranslatedText | The translation as submitted in the AddTranslation() method call.                |
| Uri            | The URI applied in the AddTranslation() method call.                             |
| User           | The user name                                                                    |

**Exceptions**

| Exception                                                                                                       | Message                                                                           | Conditions                                                                                                                                                                                                                       |
|-----------------------------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| [ArgumentOutOfRangeException](https://msdn.microsoft.com/en-us/library/system.argumentoutofrangeexception.aspx) | The parameter '**maxDateUtc**' must be greater than or equal to '**minDateUtc**'. | The value of the parameter **maxDateUtc** is lesser than the value of the parameter **minDateUtc**.                                                                                                                              |
| TranslateApiException                                                                                           | IP is over the quota.                                                             |  The limit for the number of requests per minute is reached.   The request size remains limited at 10000 characters.  An hourly and a daily quota limit the number of characters that the Microsoft, Translator API will accept. |
|                                                                                                                 | AppId is over the quota.                                                          | The application ID exceeded the hourly or daily quota.                                                                                                                                                                           |

>[!NOTE]
>The quota will adjust to ensure fairness among all users of the service. 

**Example**
> [!div class="op_single_selector"]
> - [C#](ctf-getusertranslations-example-csharp.md)
> - [PHP](ctf-getusertranslations-example-php.md)


## GetUserTranslationCounts Method

This method gets the count of translations that are created by the user. It provides the list of translation counts grouped by the uriPrefix, from, to, user, minRating, and maxRating request parameters. 

**Signature C#**

UserTranslationCount[] **GetUserTranslationCounts**(

            string appId,
			
            string uriPrefix,
			
            string from,
			
            string to,
			
            int? minRating,
			
            int? maxRating,
			
            string user, 
			
            string category
			
            DateTime? minDateUtc,
			
            DateTime? maxDateUtc,
			
            int? skip,
			
            int? take);
		
            
**Parameters**

| Parameter  | Description                                                                                                                                                                                                                                         |
|------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| appld      | Required. If the Authorization header is used, leave the appid field empty,else specify a string containing "Bearer" + " " + access token.                                                                                                          |
| uriPrefix  | Optional. A string containing prefix of URI of the translation.                                                                                                                                                                                     |
| from       | Optional. A string representing the language code of the translation text.                                                                                                                                                                          |
| to         | Optional. A string representing the language code to translate the text into.                                                                                                                                                                       |
| minRating  | Optional. An integer value representing the minimum quality rating for the,translated text. The valid value is between -10 and 10. The default value is 1.                                                                                          |
| maxRating  | Optional. An integer value representing the maximum quality rating for the,translated text. The valid value is between -10 and 10. The default value is 1.                                                                                          |
| user       | Optional. A string that is used to filter the result based on the originator,of the submission.                                                                                                                                                     |
| category   | Optional. A string containing the category or domain of the translation.,This parameter supports only the default option general.                                                                                                                   |
| minDateUtc | Optional. The date from when you want to retrieve the translations. The date,must be in the UTC format.                                                                                                                                             |
| maxDateUtc | Optional. The date till when you want to retrieve the translations. The date,must be in the UTC format.                                                                                                                                             |
| skip       | Optional. The number of results that you want to skip on a page. For example,,if you want the skip the first 20 rows of the results and view from the 21st result,record, specify 20 for this parameter. The default value for this parameter is 0. |
| take       | Optional. The number of results that you want to retrieve. The maximum number of each request is 100. The default is 100.                                                                                                                           |
>Note: The skip and take request parameters enable pagination for a large number of result records. 

Return value

The result set contains array of the **UserTranslationCount**. Each UserTranslationCount has the following elements: 

| Field  | Description                                                                      |
|--------|----------------------------------------------------------------------------------|
| Count  | The number of results that is retrieved.                                         |
| From   | The source language                                                              |
| Rating | The rating that is applied by the submitter in the AddTranslation() method call. |
| To     | The target language.                                                             |
| Uri    | The URI applied in trhe AddTranslation() method call.                            |
| USer   | The user name                                                                    |

**Exceptions**

| Exception                                                                                                        | Message                                                                           | Conditions                                                                                                                                                                                                                     |
|------------------------------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| [ArgumentsOutOfRangeException](https://msdn.microsoft.com/en-us/library/system.argumentoutofrangeexception.aspx) | The parameter **'maxDateUtc'** must be greater than or equal to **'minDateUtc'**. | The value of the parameter **maxDateUtc** is lesser than the value of the parameter **minDateUtc**.                                                                                                                            |
| TranslateApiException                                                                                            | IP is over the quota.                                                             |  The limit for the number of requests per minute is reached.   The request size remains limited at 10000 characters. An hourly and a daily quota limit the number of characters that the Microsoft Translator API will accept. |
|                                                                                                                  | AppId is over the quota.                                                          | The application ID exceeded the hourly or daily quota.                                                                                                                                                                         |

>[!NOTE]
>The quota will adjust to ensure fairness among all users of the service.

### **Example** ###

> [!div class="op_single_selector"]
> - [C#](ctf-getusertranslationcounts-example-csharp.md)
> - [PHP](ctf-getusertranslationcounts-example-php.md)

